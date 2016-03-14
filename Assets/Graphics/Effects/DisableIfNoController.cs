using UnityEngine;
using System.Collections;

public class DisableIfNoController : MonoBehaviour
{
    [SerializeField] GameObject m_optionalTarget = null;
    GameObject m_myTarget = null;
    [SerializeField] private int m_myControllerNumber;
    private int m_currentNumber = 0;
    Manager m_managerP1 = null;

    private void Start()
    {
        if (m_optionalTarget == null)
        {
            m_myTarget = gameObject;
        }
        else
        {
            m_myTarget = m_optionalTarget;
        }
    }

    private void Update()
    {
        if (m_managerP1 == null)
        {
            m_managerP1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        }
        else
        {
            if (m_managerP1.Controllers != m_currentNumber)
            {
                if (m_myControllerNumber > m_managerP1.Controllers)
                {
                    m_myTarget.SetActive(false);

                }
                if (m_myControllerNumber <= m_managerP1.Controllers)
                {
                    m_myTarget.SetActive(true);

                }
                m_currentNumber = m_managerP1.Controllers;
            }
        }
    }
	
}
