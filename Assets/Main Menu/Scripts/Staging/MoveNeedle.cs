using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveNeedle : MonoBehaviour
{
    private List<Manager> m_teamManagers;
    private Rigidbody m_ridigbody;
    [SerializeField] private float m_speed = 500;

    void Start ()
    {
        GetTeams();
        m_ridigbody = GetComponent<Rigidbody>();
    }
	

	void Update ()
    {
        GetMovement();
    }

    private void GetMovement()
    {


        foreach (Manager controller in m_teamManagers)
        {
            float y = -Input.GetAxis(controller.Inputs[13].name);
            float x = Input.GetAxis(controller.Inputs[12].name);

            m_ridigbody.AddForce(new Vector3(x * m_speed, y * m_speed));
        }

    }

    private void GetTeams()
    {
        m_teamManagers = new List<Manager>();
        int controllers = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
        for (int i = 0; i < controllers; i++)
        {
            m_teamManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }
    }
}
