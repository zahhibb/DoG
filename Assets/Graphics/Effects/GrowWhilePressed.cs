using UnityEngine;
using System.Collections;

public class GrowWhilePressed : MonoBehaviour {

    [SerializeField] private int m_controller;
    private Manager m_myManager;
    [SerializeField] private int m_buttonIndex;

    [SerializeField] private float m_maxSize = 5;
    [SerializeField] private float m_growthPerSecond;

    private Vector3 m_originalScale;

    private void Start()
    {
        m_originalScale = gameObject.transform.localScale;
        m_myManager = GameObject.FindGameObjectWithTag("ManagerP" + m_controller).GetComponent<Manager>();
    }

    private void Update()
    {
        if (Input.GetButton(m_myManager.Inputs[m_buttonIndex].name))
        {
            if (gameObject.transform.localScale.x < m_originalScale.x * m_maxSize) 
            gameObject.transform.localScale += (gameObject.transform.localScale * ((m_growthPerSecond * Time.deltaTime)));
        }
        else
        {
            gameObject.transform.localScale = m_originalScale;
        }
    }
}
