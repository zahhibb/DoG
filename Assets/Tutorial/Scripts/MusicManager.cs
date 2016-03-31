using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    // MainMenuManager should include arrays of sound effects/music voices.
    private Manager[] m_playerManagers;
    private AudioSource[] m_audioSources;
    private AudioSource[] m_musicSources;
    private float[] m_musicVolumes;
    [SerializeField] int m_numberOfPlayers = 4;

	private void Start ()
    {
        GetManagers();
        MakeAudioSources();
        StartTheMusics();
    }

    private void Update()
    {
        //for (int i = 0; i < m_numberOfPlayers; i++)
        //{
        //    UpdateVolume(m_playerManagers[i]);
        //}
    }
    private void GetManagers()
    {
        m_playerManagers = new Manager[m_numberOfPlayers];
        for (int i = 0; i < m_numberOfPlayers; i++)
        {
            m_playerManagers[i] = (GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }
    }

    private void StartTheMusics()
    {
        int musicIndex = 0;
        for (int i = 1; i < m_numberOfPlayers; i++)
        {
            m_musicSources[i].PlayOneShot(m_playerManagers[i - 1].Sounds[musicIndex].clip, m_playerManagers[i - 1].Sounds[musicIndex].volume);
        }
    }

    private void MakeAudioSources()
    {
        // 0 - Main
        // 1 - P1
        // 2 - P2
        // 3 - P3
        // etc...

        m_audioSources = new AudioSource[m_numberOfPlayers + 1];
        m_musicSources = new AudioSource[m_numberOfPlayers + 1];
        m_musicVolumes = new float[m_numberOfPlayers + 1];

        m_audioSources[0] = gameObject.AddComponent<AudioSource>();
        for (int i = 1; i < m_numberOfPlayers; i++)
        {
            m_audioSources[i] = gameObject.AddComponent<AudioSource>();
            m_musicSources[i] = gameObject.AddComponent<AudioSource>();
            m_musicVolumes[i - 1] = m_playerManagers[i].Sounds[0].volume;
        }
    }

    public void TestSound(int index, Manager manager) // index är inte så gött, finns det ett najsigare sätt tro?
    {
        // inte detta, men med nån fin funktion av Sounds[x].duration.
        m_musicVolumes[manager.TeamNumber - 1] = 0f;
        m_audioSources[manager.TeamNumber].PlayOneShot(manager.Sounds[index].clip);

    }

    private float VolumeEaseUp(float volume)
    {
        float gainedVolume = Mathf.Clamp((volume + (1 * Time.deltaTime)), 0, 1);
        return gainedVolume;
    }

    private IEnumerator MusicVolumeDucking(float duration, Manager manager)
    {
        // lol detta suger, måste returnera en funktion till update, dvs en bool per musikspår antar jag.
        m_musicSources[manager.TeamNumber].volume = 0f;
        yield return new WaitForSeconds(duration);
        m_musicSources[manager.TeamNumber].volume = manager.Sounds[0].volume;

    }
}
