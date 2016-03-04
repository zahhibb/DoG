using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour {
    
    private List<PlayerScript> m_players;
	// Use this for initialization
	void Start () {
        m_players = new List<PlayerScript>();
         Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        int loop = player1Manager.Controllers;

        m_players.Add(new PlayerScript());
        m_players[0].AssignManager(player1Manager);
        for (int i = 1; i < loop; i++)
        {
            m_players.Add(new PlayerScript());
            m_players[i].AssignManager(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
