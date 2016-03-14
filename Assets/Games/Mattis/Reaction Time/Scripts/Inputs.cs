using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour
{

    [SerializeField] private int m_playerNumber;
    //private Manager m_myManager;

	// Use this for initialization
	void Start ()
    {
        //m_myManager = GameObject.FindGameObjectWithTag("ManagerP" + m_playerNumber).GetComponent<Manager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /// funkar perfekomundo

        if ((Input.GetKeyDown(KeyCode.A)/*(Input.GetButtonDown(m_myManager.Inputs[0].name)*/) && (GameObject.FindGameObjectWithTag("buttonA") == true))
        {
            //Score
            Debug.Log("buttonA works mate");
        }

        if ((Input.GetKeyDown(KeyCode.S)/*(Input.GetButtonDown(m_myManager.Inputs[1].name)*/) && (GameObject.FindGameObjectWithTag("buttonB") == true))
        {
            //Score
            Debug.Log("buttonB works mate");
        }

        if ((Input.GetKeyDown(KeyCode.D)/*(Input.GetButtonDown(m_myManager.Inputs[2].name)*/) && (GameObject.FindGameObjectWithTag("buttonX") == true))
        {
            //Score
            Debug.Log("buttonX works mate");
        }

        if ((Input.GetKeyDown(KeyCode.F)/*(Input.GetButtonDown(m_myManager.Inputs[3].name)*/) && (GameObject.FindGameObjectWithTag("buttonY") == true))
        {
            //Score
            Debug.Log("buttonY works mate");
        }
    }
}