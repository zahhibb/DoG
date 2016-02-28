using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneToStaging : MonoBehaviour {

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void DoneInMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
    }
}
