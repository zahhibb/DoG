using UnityEngine;
using System.Collections;

public class DisableIfNoController : MonoBehaviour {

    [SerializeField] private int m_myControllerNumber;

	void Start ()
    {
	    if (GameObject.FindGameObjectWithTag("ManagerP1"))
        {
            if (GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers < m_myControllerNumber)
            {
                gameObject.SetActive(false);
            }
        }
	}
	
}
