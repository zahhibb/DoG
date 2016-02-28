using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    [SerializeField] private Camera m_tutorialCam = null;
    [SerializeField] private Canvas m_canvas = null;
    [SerializeField] private float m_totalTime = 10.0f;

    private void Awake()
    {
        Time.timeScale = 0;
        //Time.fixedDeltaTime = 0;
        m_canvas.enabled = true;
        m_tutorialCam.enabled = true;
        StartCoroutine(CountDown(m_totalTime));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
        if (Time.unscaledTime > m_totalTime)
        {
            Destroy(gameObject);
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        }
    }

    private void PauseButton()
    {
        m_canvas.enabled = !m_canvas.enabled;
        Time.timeScale = (Time.timeScale == 0)? 1 : 0;
        //Time.fixedDeltaTime = (Time.fixedDeltaTime == 0)? 1 : 0;
    }

    private void Quit()
    {
        Application.Quit();
    }

    private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}