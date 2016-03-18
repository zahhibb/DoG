using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class CoinPlayerSpawner : MonoBehaviour {
    [SerializeField]
    GameObject m_player;//is set inside the Unity Engine
                        // Use this for initialization
    private List<GameObject> m_players;
    private double m_width;//half the width
    private double m_height;//half the height
    void Start ()
    {
        m_width = Camera.main.orthographicSize;
        m_height = Camera.main.orthographicSize * (Screen.width / Screen.height);
        m_players = new List<GameObject>();
        int loop = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
        for (int i = 0; i < loop; i++)
        {
            
            m_players.Add(Instantiate(m_player));
            m_players[i].GetComponent<PlayerScript>().AssignManager(GameObject.FindGameObjectWithTag("ManagerP"+(i+1)).GetComponent<Manager>());
            switch (i)
            {
                case 0:
                    m_players[i].GetComponent<PlayerScript>().SetPlayerPosition(new Vector3((float)(m_width*-1.6),(float)(m_height*0.4),0));
                    break;
                case 1:
                    m_players[i].GetComponent<PlayerScript>().SetPlayerPosition(new Vector3((float)(m_width * 1.6), (float)(m_height * 0.4), 0));
                    break;
                case 2:
                    m_players[i].GetComponent<PlayerScript>().SetPlayerPosition(new Vector3((float)(m_width * -1.6), (float)(m_height * -0.4), 0));
                    break;
                case 3:
                    m_players[i].GetComponent<PlayerScript>().SetPlayerPosition(new Vector3((float)(m_width * 1.6), (float)(m_height * -0.4), 0));
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i< m_players.Count;i++)
        {
            if (m_players[i].GetComponent<PlayerScript>().GetShallDestroy()==true)
            {

                m_players[i].GetComponent<PlayerScript>().SetScore(8-m_players.Count * 2);
                Destroy(m_players[i]);
                m_players.RemoveAt(i);
            }
        }
        if (m_players.Count == 0)
        {
            SceneManager.LoadScene("Staging");
        }
    }
}
