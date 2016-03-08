using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneRouter : MonoBehaviour {

    [SerializeField] private string m_sceneChoice;
    [SerializeField] private float m_totalTime = 2f;
    [SerializeField] private GameObject m_countDownParent;
    [SerializeField] GameObject m_spinCountdown;
    [SerializeField] GameObject m_backgroundCutout;
    [SerializeField] GameObject m_background;
    [SerializeField] Color m_backgroundColor;

    private bool m_isCounting = false;
    private float m_lastTime = 0f;

    // serialize your very own tutorial here.
    [SerializeField] Object m_sampleTutorial = null;

	private void Start ()
    {
        m_sceneChoice = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().ChosenScene;
        MakeTutorial(m_sceneChoice);
    }

    private void Update()
    {
        UpdateBackground();

        if (!m_isCounting)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Destroy(m_sampleTutorial);
                StartCoroutine(LoadScene(m_totalTime));
                SpinCountdown();
            }
            
        }
        UpdateCounter();
    }

    private void MakeTutorial(string choice)
    {
        switch (choice)
        {

            // and add a case for your game in this switch.

            case "Sample":
                GameObject specificPrefab = (GameObject)Instantiate(m_sampleTutorial, transform.position, transform.rotation);
                m_totalTime = specificPrefab.GetComponent<Pause>().TotalTime;
                break;
            case "Floppy1":
                m_countDownParent.GetComponentInChildren<Text>().text = "flopp your boys";
                StartCoroutine(LoadScene(m_totalTime));
                SpinCountdown();
                break;
        }
        
       
    }

    private void StartScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    private IEnumerator LoadScene(float time)
    {
        // add a little bit to finish animating :/
        time += 0.8f;
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneChoice);
    }

    private void SpinCountdown()
    {
        m_countDownParent.GetComponentInChildren<Text>().text = "game starting";
        m_countDownParent.GetComponentInChildren<PlayImage>().PlayLoop();
        m_isCounting = true;
    }

    private void UpdateBackground()
    {
        m_backgroundCutout.GetComponent<Image>().color = m_backgroundColor;
        m_background.GetComponent<Image>().color = m_backgroundColor;
    }

    private void UpdateCounter()
    {
        if (m_isCounting)
        {
            if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "ready";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 1)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "get set";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 2)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "on your marks";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 3)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "game starting";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 4)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "game starting";
            }

        }
        else
        {
            m_lastTime = Time.timeSinceLevelLoad;
        }
    }
}
