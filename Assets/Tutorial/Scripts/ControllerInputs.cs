using UnityEngine;
using System.Collections;

public class ControllerInputs : MonoBehaviour {

    [SerializeField]
    int m_player;
    [SerializeField]
    string m_A;
    private Manager m_manager;

    void Start()
    {
        m_manager = GameObject.FindGameObjectWithTag("ManagerP" + m_player).GetComponent<Manager>();
    }

    void Update()
    {
        if (Input.GetButtonDown(m_manager.Inputs[0].name))
        {
            SendMessage(m_A);
        }

    }       
}
