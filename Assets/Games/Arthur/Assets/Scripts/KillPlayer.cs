using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour {

    private int m_scoreVar = 1;

    List<float> m_playerY = new List<float>();
    private PlayerController m_playerPlacement;
    private PlayerManager m_playerManager;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // give score to players
            m_playerPlacement = other.GetComponent<PlayerController>();
            m_playerManager = GameObject.FindGameObjectWithTag("FindableUI").GetComponent<PlayerManager>();

            GameObject.FindGameObjectWithTag("ManagerP" + m_playerPlacement.PlayerNumber).GetComponent<Manager>().Score += m_playerManager.ScoreBase;
            m_playerManager.ScoreBase *= 2;
            DestroyObject(other.gameObject);
        }
    }

}
