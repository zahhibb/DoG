using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonA;
    [SerializeField]
    private GameObject buttonB;
    [SerializeField]
    private GameObject buttonX;
    [SerializeField]
    private GameObject buttonY;

    private int m_countdown;       //Time before button is instantiated
    private int m_buttonChoice;    //Which button to instantiate

    // Use this for initialization
    void Start ()
    {
        m_buttonChoice = Random.Range(1, 5);
        m_countdown = Random.Range(1, 10);
        StartCoroutine(ExecuteAfterTime(m_countdown));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //m_buttonChoice = Random.Range(1, 5);
        //m_countdown = Random.Range(1, 2);

        //if (m_buttonChoice == 1)
        //{
        //    Instantiate(buttonA);
        //}
        //else if (m_buttonChoice == 2)
        //{
        //    Instantiate(buttonB);
        //}
        //else if (m_buttonChoice == 3)
        //{
        //    Instantiate(buttonX);
        //}
        //else if (m_buttonChoice == 4)
        //{
        //    Instantiate(buttonY);
        //}
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(m_countdown);
        if(m_buttonChoice == 1)
        {
            Instantiate(buttonA);
        }
        else if (m_buttonChoice == 2)
        {
            Instantiate(buttonB);
        }
        else if (m_buttonChoice == 3)
        {
            Instantiate(buttonX);
        }
        else if (m_buttonChoice == 4)
        {
            Instantiate(buttonY);
        }
    }
}
