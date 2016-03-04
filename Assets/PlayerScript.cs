using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private Manager m_manager;
    private Rigidbody2D m_rb2d;
    public void AssignManager(Manager manager)
    {
        m_manager = manager;
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Input.GetAxis(m_manager.Inputs[6].name);


    }
}
