using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Object m_player;
    private List<Manager> m_playerManagers;

    private int m_scoreBase = 1;

    private int m_scoreVar = 1;


    // Use this for initialization
    void Start()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        int loop = player1Manager.Controllers;
        m_scoreBase = SetScore(loop);
        m_playerManagers.Add(player1Manager);
        for (int i = 1; i < loop; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }

        for (int i = 0; i < player1Manager.Controllers ; i++)
        {
            GameObject player = (GameObject)Instantiate(m_player, new Vector3(0f +(i*1.5f) ,1f,0f), Quaternion.Euler(0, 0, 0));
            PlayerController playerController = player.GetComponent<PlayerController>();

            playerController.MyManager = m_playerManagers[i];
            playerController.PlayerNumber = i + 1;

            player.GetComponent<SpriteRenderer>().color = m_playerManagers[i].PlayerColor;
        }

        //renderer.material.color = Color(Random.Range(0.0, 1.0), Random.Range(0.0, 1.0), Random.Range(0.0, 1.0));
    }
    // Update is called once per frame
    void Update()
    {

    }

    private int SetScore(int playersCount)
    {
        if (playersCount == 2)
        {
            return 4;
        }
        else if (playersCount == 3)
        {
            return 2;
        }
        else if (playersCount == 4)
        {
            return 1;
        }
        else
        {
            return 8;
        }
    }

    public int ScoreBase
        {
            get { return m_scoreBase; }
            set { m_scoreBase = value; }
        }
}