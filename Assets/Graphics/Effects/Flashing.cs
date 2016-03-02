using UnityEngine;
using System.Collections;

public class Flashing : MonoBehaviour
{

    [SerializeField] private GameObject m_subject = null;
    [SerializeField] private float m_flashTime = 0.8f;
    private bool m_isActive;
    private float m_lastTime = 0f;
    private float m_timeSinceLast = 0f;
    private void Start()
    {
        m_isActive = gameObject.activeSelf;
        m_lastTime = Time.timeSinceLevelLoad;
    }

	void Update ()
    {
        m_timeSinceLast = Time.timeSinceLevelLoad;
        if ((m_timeSinceLast - m_lastTime) > m_flashTime)
        {
            m_subject.gameObject.SetActive(OnOff(m_isActive));
        }

    }

    private bool OnOff(bool boolean)
    {
        m_lastTime = Time.timeSinceLevelLoad;
        return (boolean) ? false : true;
    }
}
