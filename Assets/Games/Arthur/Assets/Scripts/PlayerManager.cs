using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Object m_floppyBoy;
    private List<Manager> m_playerManagers;
    

    // Use this for initialization
    void Start()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        int loop = player1Manager.Controllers;
        m_playerManagers.Add(player1Manager);
        for (int i = 1; i < loop; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }

        for (int i = 0; i < player1Manager.Controllers ; i++)
        {
            GameObject player = (GameObject)Instantiate(m_floppyBoy, new Vector3(0f +(i*1.5f) ,1f,0f), Quaternion.Euler(0, 0, 0));
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.MyManager = m_playerManagers[i];
            playerController.PlayerNumber = i + 1;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}