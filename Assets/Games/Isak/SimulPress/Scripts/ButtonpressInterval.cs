using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonpressInterval : MonoBehaviour {

    // try to make this instantiable per controller (input is the crux)

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
    private string[] m_buttonNames;
    private Button[] m_pressedP1;
    private List<Manager> m_playerManagers;

    void Start ()
    {
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
        LameGame();
        //CheckButton(m_pressedP1);
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

    private void LameGame()
    {
        foreach (Manager team in m_playerManagers)
        {
            if (Input.GetButtonDown(team.Inputs[0].name))
            {
                Debug.Log("team number " + team.TeamNumber + " pressed " + team.Inputs[0].name);
                BackToStaging(team.TeamNumber);
            }
        }
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
}

