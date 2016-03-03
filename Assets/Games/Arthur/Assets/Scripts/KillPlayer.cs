using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour {


    List<float> m_playerY = new List<float>();
    private int m_onceCheck = 0;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && m_onceCheck == 0)
        {
            m_onceCheck = 1;


            // give score to le players


            // load staging menu
            UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");





            //for (var i = 0; i < m_playerY.Count; i++)
            //{
            //    print(m_playerY[i]);
            //    //print("yoloswagerinho");
            //}
            //m_playerY.Sort();
            //m_playerY.Reverse();
            //for (var i = 0; i < m_playerY.Count; i++)
            //{
            //    print(m_playerY[i]);
            //    //print("nice meme m8");
            //}

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            m_playerY.Add(other.transform.localPosition.y);
            DestroyObject(other.gameObject);
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
        }
    }

}
