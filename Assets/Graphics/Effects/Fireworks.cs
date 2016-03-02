using UnityEngine;
using System.Collections;

public class Fireworks : MonoBehaviour
{
    [SerializeField] private Object m_fireWork = null;
    [SerializeField] private float m_fireRate = 1.6f;
    private GameObject currentFirework = null;
    private bool m_isReady = true;

    void Update()
    {
        if (m_isReady)
        {
            CountDown(m_fireRate);
            m_isReady = false;
        }
    }

    private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        currentFirework = (GameObject)Instantiate(m_fireWork, new Vector3(0f, 0f, 0f), Quaternion.Euler(0, 0, 0));
        SelfDestruct selfDestructor = currentFirework.AddComponent<SelfDestruct>();
        selfDestructor.LifeTime = 0.8f;
        m_isReady = true;
    }
}
