using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankGameController : MonoBehaviour {

    [SerializeField] private GameObject m_tank;
    private List<Manager> m_playerManagers;

    private Manager m_manager;

	void Start () {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();

        int playerCount = player1Manager.Controllers;
        
        /*
            Create instance of score for each player/controller
        */

        m_playerManagers.Add(player1Manager);

        for (int i = 1; i < playerCount; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }

        for (int i = 0; i < player1Manager.Controllers; i++)
        {
            GameObject player = (GameObject)Instantiate(m_tank, new Vector3(transform.position.x + (i * 7f), transform.position.y + 1f, transform.position.z), Quaternion.Euler(0, 0, 0));

            player.GetComponentInChildren<MovementController>().TriggerAxis = m_playerManagers[i].Inputs[16].name;
            player.GetComponentInChildren<MovementController>().LeftStickX = m_playerManagers[i].Inputs[12].name;
            player.GetComponentInChildren<TurretController>().RightStick = m_playerManagers[i].Inputs[14].name;
            player.GetComponentInChildren<ShootingContoller>().RightBumper = m_playerManagers[i].Inputs[5].name;
        }
    }
	
	
	void Update () {
	    /*
            Set score
        */
	}
}
