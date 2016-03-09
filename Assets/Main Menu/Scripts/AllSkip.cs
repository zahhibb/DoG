using UnityEngine;
using System.Collections;

public class AllSkip : MonoBehaviour
{

    private bool m_team1Pressed = false;
    private bool m_team2Pressed = false;
    private bool m_team3Pressed = false;
    private bool m_team4Pressed = false;
    private int m_teamAmount = 0;

    private void Start()
    {
        ResetChecks();
    }

    public bool AllTeamsPressed(int button)
    {
        CheckAmount();

        if (!GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Active) { m_team1Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Active) { m_team2Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Active) { m_team3Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Active) { m_team4Pressed = true; }

        Debug.Log("Button  on 1: " + m_team1Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Active);
        Debug.Log("Button  on 2: " + m_team2Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Active);
        Debug.Log("Button  on 3: " + m_team3Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Active);
        Debug.Log("Button  on 4: " + m_team4Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Active);

        // probably add serialized Highlights here, to update on update.

        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Inputs[button].name)) { m_team1Pressed = true; Debug.Log(m_team1Pressed); }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Inputs[button].name)) { m_team2Pressed = true; Debug.Log(m_team2Pressed); }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Inputs[button].name)) { m_team3Pressed = true; Debug.Log(m_team3Pressed); }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Inputs[button].name)) { m_team4Pressed = true; Debug.Log(m_team4Pressed); }

        if (m_team1Pressed && m_team2Pressed && m_team3Pressed && m_team4Pressed)
        {
            m_team1Pressed = false;
            m_team2Pressed = false;
            m_team3Pressed = false;
            m_team4Pressed = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetChecks()
    {
        m_team1Pressed = false;
        m_team2Pressed = false;
        m_team3Pressed = false;
        m_team4Pressed = false;
    }

    private void CheckAmount()
    {
        if (m_teamAmount != GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers)
        {
            Debug.Log("CHANGED AMOUNTS, RESETTING");    
            m_teamAmount = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
            ResetChecks();
        }
    }

    
}
