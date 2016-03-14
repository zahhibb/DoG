using UnityEngine;
using System.Collections;

public class GrowFromParam : MonoBehaviour
{
    [SerializeField] private int m_controller;
    private Manager m_myManager;

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
        float scoreLerp = Mathf.InverseLerp(0, 24, m_myManager.Score);
        float scaleLerp = Mathf.Lerp(1, m_originalScale.x * m_maxSize, scoreLerp);

        if (m_myManager.Active)
        {
            if (gameObject.transform.localScale.x < m_originalScale.x * (m_originalScale.x * m_maxSize))
                gameObject.transform.localScale = (m_originalScale * scaleLerp);
        }
    }
}
