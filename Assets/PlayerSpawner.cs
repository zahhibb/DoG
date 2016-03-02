using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour {
    
    private List<Manager> m_playerManagers;
	// Use this for initialization
	void Start () {
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        int loop = player1Manager.Controllers;
        m_playerManagers.Add(player1Manager);
        for (int i = 1; i < loop; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP"+(i+1)).GetComponent<Manager>());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
