using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Image[] m_teamIcons;

    [SerializeField]
    private GameObject m_buttonA;
    [SerializeField]
    private GameObject m_buttonB;
    [SerializeField]
    private GameObject m_buttonX;
    [SerializeField]
    private GameObject m_buttonY;

    private List<Manager> m_playerManagers = new List<Manager>();
    private int[] m_pressCounts = new int[4] { 1, 1, 1, 1 };

    private int m_wrongButton = 0;
    private int m_countdown;       //Time before button is instantiated
    private int m_buttonChoice;    //Which button to instantiate
    private int m_score = 8;           //Amount of score to give to winner
    
    void Start ()
    {
        FindTeams();
        m_buttonChoice = Random.Range(1, 5);
        m_countdown = Random.Range(1, 10);
        StartCoroutine(ExecuteAfterTime(m_countdown));
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckButtons();
        if (m_playerManagers.Count < 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        m_pressCounts = new int[4]{ 1, 1, 1, 1};
        yield return new WaitForSeconds(m_countdown);
        if(m_buttonChoice == 1)
        {
            Instantiate(m_buttonA);
        }
        else if (m_buttonChoice == 2)
        {
            Instantiate(m_buttonB);
        }
        else if (m_buttonChoice == 3)
        {
            Instantiate(m_buttonX);
        }
        else if (m_buttonChoice == 4)
        {
            Instantiate(m_buttonY);
        }
    }

    private void CheckButtons()
    {
        foreach (Manager teamManager in m_playerManagers)
        {
            if (PlayerPressed(teamManager) && (m_pressCounts[teamManager.TeamNumber - 1] == 1))
            {
                teamManager.Score += m_score;
                m_score /= 2;
                m_pressCounts[teamManager.TeamNumber - 1] = 0;
                m_teamIcons[teamManager.TeamNumber - 1].gameObject.SetActive(false);
                m_playerManagers.Remove(teamManager);
            }

            if ((PlayerPressed(teamManager)) && (m_pressCounts[teamManager.TeamNumber - 1] == 0))
            {
                m_playerManagers.Remove(teamManager);
                m_teamIcons[teamManager.TeamNumber - 1].gameObject.SetActive(false);

            }
        }
    }

    private bool PlayerPressed(Manager myManager)
    {
            if (/*(Input.GetKeyDown(KeyCode.A)*/(Input.GetButtonDown(myManager.Inputs[0].name)) && (GameObject.FindGameObjectWithTag("buttonA") == true) && (m_pressCounts[myManager.TeamNumber-1] == 1))
        {
            
            return true;
        }

        if (/*(Input.GetKeyDown(KeyCode.S)*/(Input.GetButtonDown(myManager.Inputs[1].name)) && (GameObject.FindGameObjectWithTag("buttonB") == true) && (m_pressCounts[myManager.TeamNumber - 1] == 1))
        {
            
            return true;
        }

        if (/*(Input.GetKeyDown(KeyCode.D)*/(Input.GetButtonDown(myManager.Inputs[2].name)) && (GameObject.FindGameObjectWithTag("buttonX") == true) && (m_pressCounts[myManager.TeamNumber - 1] == 1))
        {
            
            return true;
        }

        if (/*(Input.GetKeyDown(KeyCode.F)*/(Input.GetButtonDown(myManager.Inputs[3].name)) && (GameObject.FindGameObjectWithTag("buttonY") == true) && (m_pressCounts[myManager.TeamNumber - 1] == 1))
        {
            
            return true;
        }

        if ((Input.GetButtonDown(myManager.Inputs[0].name)) || (Input.GetButtonDown(myManager.Inputs[1].name)) || (Input.GetButtonDown(myManager.Inputs[2].name)) || (Input.GetButtonDown(myManager.Inputs[3].name)) && (m_wrongButton == 0))
        {
            
            m_pressCounts[myManager.TeamNumber - 1] = 0;
            return true;
        }
        return false;
    }

    private void FindTeams()
    {
        int controllers = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
        for (int i = 1; i <= controllers; i++)
        {
            
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + i).GetComponent<Manager>());
        }
    }
}
