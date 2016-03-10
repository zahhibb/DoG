using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonpressInterval : MonoBehaviour {

    private float m_startTimeP1 = 0f;
    /*
    private float m_startTimeP2 = 0f;
    private float m_startTimeP3 = 0f;
    private float m_startTimeP4 = 0f;
    */
    private float m_endTimeP1 = 0f;
    /*
    private float m_endTimeP2 = 0f;
    private float m_endTimeP3 = 0f;
    private float m_endTimeP4 = 0f;
    */
    private bool m_coolingDown = false;

    private string[] m_buttonNames;
    private Button[] m_pressedP1;

    
    private int m_roundCount = 1;
    [SerializeField] private int m_currentWorth = 1;
    [SerializeField] private Text m_currentWorthText;

    private List<Manager> m_playerManagers;
    [SerializeField] private int m_buttonOfTheDay;

    void Start ()
    {
        m_currentWorthText.text = "1 pt";
        m_currentWorthText.color = Color.white;

        m_buttonOfTheDay = Random.Range(0, 4);
        FindTeams();
        /*
        *if (playerPerTeamAmount < x)
        *{
        *   PossibleButtonAmount = (x == 1) ? y : z;
        *}
        */

        // Turn over cards to reveal "what you pressed" (sounds retarded but is probably fun)
    }

    private void Update()
    {
        if (LameGame())
        {
            m_coolingDown = true;
            StartCoroutine(SuspendPresses(1f));
        }
    }

    private struct Button
    {
        public string name;
        public bool pressed; //getters in structs? :|
    };

    private enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };

    private void CheckButton(Button[] buttons)
    {
        bool isThatAll = false;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].pressed == false && m_startTimeP1 == 0)
            {
                buttons[i].pressed = (Input.GetKeyDown(buttons[i].name));
                // send to funky bar filling up and/or cards flipping over
                m_startTimeP1 = Time.realtimeSinceStartup;
                if (!isThatAll)
                {
                    isThatAll = true;
                }
            }
        }        
    }

    private Manager LameGame()
    {
        foreach (Manager team in m_playerManagers)
        {
            if (Input.GetButtonDown(team.Inputs[m_buttonOfTheDay].name))
            {
                Debug.Log("team number " + team.TeamNumber + " pressed " + team.Inputs[m_buttonOfTheDay].name);
                BackToStaging(team.TeamNumber);
                return team;
            }
            else if (Input.GetButtonDown(team.Inputs[0].name))
            {
                return team;
            }
            else if (Input.GetButtonDown(team.Inputs[1].name))
            {
                return team;
            }
            else if (Input.GetButtonDown(team.Inputs[2].name))
            {
                return team;
            }
            else if (Input.GetButtonDown(team.Inputs[3].name))
            {
                return team;
            }

        }
        return null;
    }

    public void BackToStaging(int player)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");

        GameObject.FindGameObjectWithTag("ManagerP" + player).GetComponent<Manager>().Score += 8;
        
    }

    private void FindTeams()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        int loop = player1Manager.Controllers;
        m_playerManagers.Add(player1Manager);
        for (int i = 1; i < loop; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }
    }

    private IEnumerator SuspendPresses(float time)
    {
        yield return new WaitForSeconds(time);
        m_coolingDown = false;
        if (m_roundCount > 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
        }

    }
}

