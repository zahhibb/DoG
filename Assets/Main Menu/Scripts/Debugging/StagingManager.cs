using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StagingManager : MonoBehaviour
{
    [SerializeField] Text[] m_scoreTexts;
    [SerializeField] Text m_rounds;

    Manager m_manager1;
    Manager m_manager2;
    Manager m_manager3;
    Manager m_manager4;

    private void Start()
    {
        // loop towards manager amount here instead
        m_manager1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_manager2 = GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>();
        m_manager3 = GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>();
        m_manager4 = GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>();

        if (CountRounds(m_manager1) <= 1)
        {
            m_rounds.text = "round " + m_manager1.Rounds + "/3!";
        }
        else
        {
            if (m_manager1.Score > m_manager2.Score && m_manager1.Score > m_manager3.Score && m_manager1.Score > m_manager4.Score)
            {
                m_rounds.text = m_manager1.TeamName + " is the winnewr";
                m_manager1.ChosenScene = m_manager1.TeamName;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerShowOff");
            }
            if (m_manager2.Score > m_manager1.Score && m_manager2.Score > m_manager3.Score && m_manager2.Score > m_manager4.Score)
            {
                m_rounds.text = m_manager2.TeamName + " is the winnewr";
                m_manager1.ChosenScene = m_manager2.TeamName;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerShowOff");
                // Declare Winner, show-off scene before returning to main!
            }
            if (m_manager3.Score > m_manager2.Score && m_manager3.Score > m_manager1.Score && m_manager3.Score > m_manager4.Score)
            {
                m_rounds.text = m_manager3.TeamName + " is the winnewr";
                m_manager1.ChosenScene = m_manager3.TeamName;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerShowOff");
                // Declare Winner, show-off scene before returning to main!
            }
            if (m_manager4.Score > m_manager2.Score && m_manager4.Score > m_manager3.Score && m_manager4.Score > m_manager1.Score)
            {
                m_rounds.text = m_manager4.TeamName + " is the winnewr";
                m_manager1.ChosenScene = m_manager4.TeamName;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerShowOff");
                // Declare Winner, show-off scene before returning to main!
            }
            else
            {
                m_rounds.text = "It's a tie! Sudden death round!";
                // Winner-Take-All-Bonus-Round, stupid right?
            }


        }
        m_scoreTexts[0].text = m_manager1.Score + "p";
        m_scoreTexts[1].text = m_manager2.Score + "p";
        m_scoreTexts[2].text = m_manager3.Score + "p";
        m_scoreTexts[3].text = m_manager4.Score + "p";

    }

    /*
    private void Update()
    {
            DebugButtons();
    }
    */

    public void BackToMain()
    {
        if (m_manager1.Rounds > 3)
        {
            m_manager1.Rounds = 0;
            m_manager1.Score = 0;
            m_manager2.Score = 0;
            m_manager3.Score = 0;
            m_manager4.Score = 0;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void LoadTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    }

    // The targeted functions for Debug buttons for testing purposes:
    public void LoadAntonsAliens()
    {
        m_manager1.ChosenScene = "Aliens";
        LoadTutorial();
    }
    public void LoadFloppy1()
    {
        m_manager1.ChosenScene = "Floppy1";
        LoadTutorial();
    }
    public void LoadSimulPress()
    {
        m_manager1.ChosenScene = "SimulPress";
        LoadTutorial();
    }
    public void LoadTankYou()
    {
        m_manager1.ChosenScene = "tanks_test";
        LoadTutorial();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // This function enables/disables the debug buttons for loop purposes.
    private int CountRounds(Manager manager)
    {
        manager.Rounds++;
        if (manager.Rounds > 3)
        {
            GameObject[] finishButtons = GameObject.FindGameObjectsWithTag("Finish");

            foreach (GameObject button in finishButtons)
            {
                button.SetActive(false);
            }

            GameObject.FindGameObjectWithTag("FindableUI").GetComponent<Text>().text = "congratulations. \n fireworks.";
        }
        return manager.Rounds;
    }

    private void CountScores()
    {

        TeamScore[] scores = new TeamScore[4];
        for (int i = 0; i <= 3; i++)
        {
            Manager currentManager = GameObject.FindGameObjectWithTag("ManagerP" + i).GetComponent<Manager>();
            scores[i].score = currentManager.Score;
            scores[i].name = currentManager.gameObject.tag;
        }
        
    }

    struct TeamScore
    {
        public int score;
        public string name;
    }

    private bool CheckButton(Manager controller, int buttonIndex)
    {
        return Input.GetButtonDown(controller.Inputs[buttonIndex].name);
    }

    private float CheckAxis(Manager controller, int buttonIndex)
    {
        return Input.GetAxisRaw(controller.Inputs[buttonIndex].name);
    }

    /* Debug Controller Buttons for choosing scenes.
    private void DebugButtons()
    {
        if (m_manager1.Rounds <= 3)
        {
            if (CheckButton(m_manager1, 0))
            {
                //LoadFloppy1();
                m_manager1.ChosenScene = "Floppy1";
                LoadTutorial();
            }
            if (CheckButton(m_manager2, 0))
            {
                //LoadFloppy1();
                m_manager1.ChosenScene = "Floppy1";
                LoadTutorial();
            }

            if (CheckButton(m_manager3, 0))
            {
                //LoadFloppy1();
                m_manager1.ChosenScene = "Floppy1";
                LoadTutorial(); ;
            }
            if (CheckButton(m_manager4, 0))
            {
                //LoadFloppy1();
                m_manager1.ChosenScene = "Floppy1";
                LoadTutorial();
            }


            if (CheckButton(m_manager1, 1))
            {
                LoadSimulPress();
            }
            if (CheckButton(m_manager2, 1))
            {
                LoadSimulPress();
            }

            if (CheckButton(m_manager3, 1))
            {
                LoadSimulPress();
            }
            if (CheckButton(m_manager4, 1))
            {
                LoadSimulPress();
            }
        }

        if (CheckButton(m_manager1, 2))
        {
            BackToMain();
        }
        if (CheckButton(m_manager2, 2))
        {
            BackToMain();
        }

        if (CheckButton(m_manager3, 2))
        {
            BackToMain();
        }
        if (CheckButton(m_manager4, 2))
        {
            BackToMain();
        }


        if (CheckButton(m_manager1, 3))
        {
            QuitGame();
        }
        if (CheckButton(m_manager2, 3))
        {
            QuitGame();
        }

        if (CheckButton(m_manager3, 3))
        {
            QuitGame();
        }
        if (CheckButton(m_manager4, 3))
        {
            QuitGame();
        }
    }
    */
}
