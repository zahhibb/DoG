using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelMaker : MonoBehaviour {

    private Rotate m_rotator;
    private List<Manager> m_teamManagers;
    [SerializeField] GameObject m_selector = null;

    void Start ()
    {
        m_rotator = GetComponent<Rotate>();
        GetTeams();
	}
	

	void Update ()
    {
        SlowDown();
        if (m_rotator.ZRot > 0)
        {
            // spawn countdownprefab with countdown lifetime
            StartCoroutine(StartMinigame(2));
        }
        m_rotator.ZRot = Mathf.Clamp(m_rotator.ZRot + ((m_rotator.ZRot > -60) ? (12 * Time.deltaTime) : (Mathf.Abs((m_rotator.ZRot / 10) * Time.deltaTime))), -350, 10);
    }

    private void SlowDown()
    {
        foreach (Manager controller in m_teamManagers)
        {
            if (Input.GetButton(controller.Inputs[1].name))
            {
                m_rotator.ZRot = Mathf.Clamp(m_rotator.ZRot + ((m_rotator.ZRot > -60) ? (60 * Time.deltaTime) : (Mathf.Abs((m_rotator.ZRot/5) * Time.deltaTime))), -350, 10);
            }
        }
    }

    private void GetTeams()
    {
        m_teamManagers = new List<Manager>();
        int controllers = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
        for (int i = 0; i < controllers; i++)
        {
            m_teamManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }
    }

    private IEnumerator StartMinigame(float time)
    {
        // play some sounds :)
        yield return new WaitForSeconds(time);
        m_teamManagers[0].ChosenScene = m_selector.GetComponent<WheelSelector>().SceneUnderNeedle;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    }
}
