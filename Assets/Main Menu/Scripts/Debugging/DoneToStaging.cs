﻿using UnityEngine;
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
	    if (Input.GetButtonDown(m_managerScript.Inputs[1].name))
        {
            DoneInMainMenu();
        }

	}

    public void DoneInMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
    }
}
