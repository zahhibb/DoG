using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private int m_onceCheck = 0;

    // Use this for initialization
    void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && m_onceCheck == 0)
        {
            m_onceCheck = 1;

            // load staging menu
            UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
        }
    }
}
