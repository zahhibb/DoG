using UnityEngine;
using System.Collections;

public class AllSkip : MonoBehaviour
{
    private bool m_team1Pressed = false;
    private bool m_team2Pressed = false;
    private bool m_team3Pressed = false;
    private bool m_team4Pressed = false;
    private int m_teamAmount = 0;


    // some optional display highlights, set them to inactive and they activate as players press the team.buttons, or vice versa.
    [SerializeField] GameObject m_displayTeam1;
    [SerializeField] GameObject m_displayTeam2;
    [SerializeField] GameObject m_displayTeam3;
    [SerializeField] GameObject m_displayTeam4;
    [SerializeField] Object m_goPrefab;

    private void Start()
    {
        ResetChecks();
    }

    public bool AllTeamsPressed(int button, string function)
    {
        CheckAmount();

        if (!GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Active) { m_team1Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Active) { m_team2Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Active) { m_team3Pressed = true; }
        if (!GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Active) { m_team4Pressed = true; }

        // probably add serialized Highlights here, to update on update.

        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Inputs[button].name))
        {
            m_team1Pressed = !m_team1Pressed;
            if (m_displayTeam1)
            {
                m_displayTeam1.SetActive(!m_displayTeam1.activeSelf);
            }
        }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Inputs[button].name))
        {
            m_team2Pressed = !m_team2Pressed;
            if (m_displayTeam2)
            {
                m_displayTeam2.SetActive(!m_displayTeam2.activeSelf);
            }
        }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Inputs[button].name))
        {
            m_team3Pressed = !m_team3Pressed;
            if (m_displayTeam3)
            {
                m_displayTeam3.SetActive(!m_displayTeam3.activeSelf);
            }
        }
        if (Input.GetButtonDown(GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Inputs[button].name))
        {
            m_team4Pressed = !m_team4Pressed;
            if (m_displayTeam4)
            {
                m_displayTeam4.SetActive(!m_displayTeam4.activeSelf);
            }
        }


        if (m_team1Pressed && m_team2Pressed && m_team3Pressed && m_team4Pressed)
        {
            m_team1Pressed = false;
            m_team2Pressed = false;
            m_team3Pressed = false;
            m_team4Pressed = false;

            //Debug.Log("Button  on 1: " + m_team1Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Active);
            //Debug.Log("Button  on 2: " + m_team2Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().Active);
            //Debug.Log("Button  on 3: " + m_team3Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().Active);
            //Debug.Log("Button  on 4: " + m_team4Pressed + " And Active is: " + GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().Active);

            StartCoroutine(WaitAndGo(0.3f, function));

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
            //Debug.Log("ALLSKIP DETECTED CHANGED PLAYER AMOUNTS, RESETTING");    
            m_teamAmount = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
            ResetChecks();
        }
    }

    private IEnumerator WaitAndGo(float time, string function)
    {
        Instantiate(m_goPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(time);
        SendMessage(function);
        // load scene from DoneToStaging? :/
    }
}
