using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour {

    private int m_scoreVar = 1;

    List<float> m_playerY = new List<float>();
    private PlayerController m_yoloSwag;
    private PlayerManager m_playerManager;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void LateUpdate()
    {
        do
        {
            
        } while (false);
       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            m_playerY.Add(other.transform.localPosition.y);

            //    for (var i = 0; i < m_playerY.Count; i++)
            //    {
            //        print(m_playerY[i]);
            //        //print("yoloswagerinho");
            //    }
            //    m_playerY.Sort();
            //    m_playerY.Reverse();
            //    for (var i = 0; i < m_playerY.Count; i++)
            //    {
            //        print(m_playerY[i]);
            //        //print("nice meme m8");
            //    }



            //if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && m_onceCheck == 0)
            //{
            //    m_onceCheck = 1;


            // give score to le players
            m_yoloSwag = other.GetComponent<PlayerController>();
            m_playerManager = GameObject.FindGameObjectWithTag("FindableUI").GetComponent<PlayerManager>();

            GameObject.FindGameObjectWithTag("ManagerP" + m_yoloSwag.PlayerNumber).GetComponent<Manager>().Score += m_playerManager.ScoreBase;
            m_playerManager.ScoreBase *= 2;
            DestroyObject(other.gameObject);
            //}
        }
    }

}
