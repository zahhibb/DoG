using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonpressInterval : MonoBehaviour
{
    [SerializeField] private Object m_go = null;
    [SerializeField] private Texture[] m_inputSprites;
    private bool m_coolingDown = false;

    //private string[] m_buttonNames;
    private List<string> m_activeInputs = new List<string>();

    private int m_roundCount = 1;
    [SerializeField] private int m_currentWorth = 1;
    [SerializeField] private Text m_currentWorthText;

    [SerializeField] private Text[] m_teamScoreTexts;
    private int[] m_teamScores;

    private List<Button> m_currentButtons;
    private List<Manager> m_playerManagers;
    [SerializeField] private int m_buttonOfTheDay;

    void Start()
    {
        m_currentWorth = 1;
        m_currentWorthText.color = Color.white;

        m_buttonOfTheDay = Random.Range(0, 4);
        FindTeams();

        foreach (Text text in m_teamScoreTexts)
        {
            text.text = "0";
        }

        m_teamScores = new int[4] { 0, 0, 0, 0 };
    }

    private void Update()
    {
        m_currentWorthText.text = " " + m_currentWorth + ".";

        if (!m_coolingDown)
        {
            if (LameGame())
            {
                m_coolingDown = true;
                StartCoroutine(SuspendPresses(1f));
                m_roundCount++;
            }
        }
    }

    private struct Button
    {
        public string name;
        public bool pressed; //getters in structs? :|
        public int inputIndex;
    };

    private enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };

    //private void CheckButton(Button[] buttons)
    //{
    //    bool isThatAll = false;
    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        if (buttons[i].pressed == false && m_startTimeP1 == 0)
    //        {
    //            buttons[i].pressed = (Input.GetKeyDown(buttons[i].name));
    //            // send to funky bar filling up and/or cards flipping over
    //            m_startTimeP1 = Time.realtimeSinceStartup;
    //            if (!isThatAll)
    //            {
    //                isThatAll = true;
    //            }
    //        }
    //    }        
    //}

    private Manager LameGame()
    {
        foreach (Manager team in m_playerManagers)
        {
            if (Input.GetButtonDown(team.Inputs[m_buttonOfTheDay].name))
            {
                Debug.Log("team number " + team.TeamNumber + " pressed " + team.Inputs[m_buttonOfTheDay].name);

                AwardPointsToPlayer(team);
                m_currentWorth *= 2;
                return team;
            }
            else if (Input.GetButtonDown(team.Inputs[0].name) || Input.GetButtonDown(team.Inputs[1].name) || Input.GetButtonDown(team.Inputs[2].name) || Input.GetButtonDown(team.Inputs[3].name))
            {
                AwardPointsToOthers(team);
                m_currentWorth *= 2;
                return team;

            }

        }
        return null;
    }

    private void AwardPointsToPlayer(Manager winningTeam)
    {

        winningTeam.Score += m_currentWorth;
        m_teamScores[winningTeam.TeamNumber - 1] += m_currentWorth;
        m_teamScoreTexts[winningTeam.TeamNumber - 1].text = m_teamScores[winningTeam.TeamNumber - 1] + "pts";

        //foreach (Manager team in m_playerManagers)
        //{
        //    if (team != winningTeam)
        //    {
        //        team.Score += m_currentWorth;
        //    }
        //}
    }

    private void AwardPointsToOthers(Manager losingTeam)
    {
        foreach (Manager team in m_playerManagers)
        {
            if (team != losingTeam)
            {
                team.Score += m_currentWorth;
                m_teamScores[team.TeamNumber - 1] += m_currentWorth;
                m_teamScoreTexts[team.TeamNumber - 1].text = m_teamScores[team.TeamNumber - 1] + "p";
            }
        }
    }

    public void BackToStaging()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");

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
        m_coolingDown = true;
        Rotate rotator = GetComponentInChildren<Rotate>();
        float rotatorRot = rotator.ZRot;
        rotator.ZRot = 0;

        yield return new WaitForSeconds(time);
        m_coolingDown = false;
        if (m_roundCount > 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
        }
        GameObject go = (GameObject)Instantiate(m_go, transform.position, transform.rotation);
        rotator.ZRot = rotatorRot;
    }

    private float EaseInOutQuartic(float time, float value, float change, float duration)
    {
        time /= duration * 2;
        if (time > 1)
        {
            return (change * time * time * time * time + value);
        }
        time -= 2;
        return (-change / 2 * (time * time * time * time - 2) + value);
    }

    private void SimulPress()
    {
        foreach (Manager team in m_playerManagers)
        {
            foreach (Button button in m_currentButtons)
            {
                if (Input.GetButtonDown(button.name))
                {

                }
            }
        }
    }

    private void MakeActiveInputs(Manager myTeam)
    {
        int indexSkipper = 0;
        for (int i = 0; i < (4 + myTeam.TeamSize * 2); i++)
        {
            int indexAdder = Random.Range(0, 1);
            m_activeInputs.Add(myTeam.Inputs[Random.Range(indexSkipper, (indexSkipper + indexAdder)) + i].name);
            indexSkipper = Mathf.Clamp(indexSkipper + indexAdder, 0, 5 - myTeam.TeamSize);

            // this won't work, but there is a way.
        }
    }
}    

  


