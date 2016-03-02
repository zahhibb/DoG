using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StagingManager : MonoBehaviour
{
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_rounds;

    private void Start()
    {
        // loop towards manager amount here instead
        Manager manager1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        Manager manager2 = GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>();
        Manager manager3 = GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>();
        Manager manager4 = GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>();

        if (CountRounds(manager1) <= 3)
        {
            m_rounds.text = "Select game for round " + manager1.Rounds + "/3!";
        }
        else
        {
            if (manager1.Score > manager2.Score && manager1.Score > manager3.Score && manager1.Score > manager4.Score)
            {
                m_rounds.text = manager1.name + " is the winnewr";
            }
            if (manager2.Score > manager1.Score && manager2.Score > manager3.Score && manager2.Score > manager4.Score)
            {
                m_rounds.text = manager1.name + " is the winnewr";
            }
            if (manager3.Score > manager2.Score && manager3.Score > manager1.Score && manager3.Score > manager4.Score)
            {
                m_rounds.text = manager1.name + " is the winnewr";
            }
            if (manager4.Score > manager2.Score && manager4.Score > manager3.Score && manager4.Score > manager1.Score)
            {
                m_rounds.text = manager1.name + " is the winnewr";
            }
            //int[] scores = { manager1.Score, manager2.Score, manager3.Score, manager4.Score };
            //int highestScore = Mathf.Max(manager1.Score, manager2.Score, manager3.Score, manager4.Score);


        }
        m_scoreText.text = "Scores   || Team 1: " + manager1.Score + " points.  " + "|| Team 1: " + manager1.Score + " points." + "  || Team 1: " + manager1.Score + " points.  " + "  || Team 1: " + manager1.Score + " points.  ";
    }

    public void BackToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

        //Destroy(GameObject.FindGameObjectWithTag("ManagerP1").gameObject);
        //Destroy(GameObject.FindGameObjectWithTag("ManagerP2").gameObject);
        //Destroy(GameObject.FindGameObjectWithTag("ManagerP3").gameObject);
        //Destroy(GameObject.FindGameObjectWithTag("ManagerP4").gameObject);
    }

    public void LoadIsItTrue()
    {
            
    }
    public void LoadAntonsAliens()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Aliens");
    }
    public void LoadFloppy1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Floppy1");
    }
    public void LoadSimulPress()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SimulPress");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private int CountRounds(Manager manager)
    {
        // Make win or lose I guess.
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

}
