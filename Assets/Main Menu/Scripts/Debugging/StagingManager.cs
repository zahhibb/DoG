using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StagingManager : MonoBehaviour
{

    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_rounds;

    private void Start()
    {
        // loop towards manager amount here
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
            int[] scores = { manager1.Score, manager2.Score, manager3.Score, manager4.Score };
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("IsItTrue");
    }
    public void LoadAntonsAliens()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Aliens");
    }
    public void LoadFloppy1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Floppy1");
    }

    int CountRounds(Manager manager)
    {
        // Make win or lose I guess.
        return manager.Score;
    }
}
