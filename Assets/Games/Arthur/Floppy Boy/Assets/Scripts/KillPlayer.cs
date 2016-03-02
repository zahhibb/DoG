using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour {

    //public LevelManager levelManager;
    List<float> m_playerY = new List<float>();
    // Use this for initialization
    void Start ()
    {
        
        //levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            m_playerY.Add(other.transform.localPosition.y);
            DestroyObject(other.gameObject);
            for (var i = 0; i < m_playerY.Count; i++)
            {
                print(m_playerY[i]);
                print("yoloswagerinho");
            }
            m_playerY.Sort();
            m_playerY.Reverse();
            for (var i = 0; i < m_playerY.Count; i++)
            {
                print(m_playerY[i]);
                print("nice meme m8");
            }

        }
       /* if (other.tag == "Player2")
        {
            m_playerY.Add(other.transform.localPosition.y);
            DestroyObject(other.gameObject);
            
        }*/
    }

}
