using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneToStaging : MonoBehaviour {

    private Manager m_managerScript;
	
    private void Start()
    {
        m_managerScript = GameObject.FindGameObjectWithTag("ManagerP"+ gameObject.name).GetComponent<Manager>();
        //Debug.Log("Canvas " + gameObject.name + ": Manager Number " + m_managerScript.TeamNumber + ".");
    }

	void Update ()
    {
	    if (Input.GetButtonDown(m_managerScript.Inputs[1].name) || Input.GetKeyDown(KeyCode.Return))
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
        if (gameObject.GetComponent<AllSkip>())
        {
            //Debug.Log(gameObject.name + " found allskipper");
            gameObject.GetComponent<AllSkip>().AllTeamsPressed(2, "DoneInMainMenu");
            Debug.Log("DoneToStaging called DoneInMainMenu from All");
        }
    }
}
