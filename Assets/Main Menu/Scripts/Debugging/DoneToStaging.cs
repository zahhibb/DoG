using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoneToStaging : MonoBehaviour
{

	void Update ()
    {
	    if ( /* Input.GetButtonDown(m_managerScript.Inputs[1].name) || */ Input.GetKeyDown(KeyCode.Return))
        {
            DoneInMainMenu();
        }
        AllSkipCheck();
    }

    public void DoneInMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
    }

    private void AllSkipCheck()
    {
        //if (GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers > 1)
        //{
            if (gameObject.GetComponent<AllSkip>())
            {
                if (gameObject.GetComponent<AllSkip>().AllTeamsPressed(2, "DoneInMainMenu"))
                {
                DoneInMainMenu();
                }
            }
        //}
    }
}
