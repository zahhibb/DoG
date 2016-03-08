using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneRouter : MonoBehaviour {

    [SerializeField] private string m_sceneChoice;
    [SerializeField] private float m_totalTime = 2f;
    [SerializeField] private GameObject m_countDownParent;
    [SerializeField] GameObject m_spinCountdown;

    private bool m_isCounting = false;
    private float m_lastTime = 0f;

    // serialize your very own tutorial here.
    [SerializeField] Object m_sampleTutorial = null;

	private void Start ()
    {
        //m_sceneChoice = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().ChosenScene;
        MakeTutorial(m_sceneChoice);

        // there should be some fancy count down animated too
        StartCoroutine(LoadScene(m_totalTime));
        SpinCountdown();
    }

    private void Update()
    {
        UpdateCounter();
    }

    private void MakeTutorial(string choice)
    {
        switch (choice)
        {

            // and add a case for it in this switch.

            case "Sample":
                GameObject specificPrefab = (GameObject)Instantiate(m_sampleTutorial, transform.position, transform.rotation);
                m_totalTime = specificPrefab.GetComponent<Pause>().TotalTime;
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
        time += 0.53f;
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneChoice);
    }

    private void SpinCountdown()
    {
        m_countDownParent.GetComponentInChildren<Text>().text = "5";
        m_countDownParent.GetComponentInChildren<PlayImage>().PlayLoop();
        m_isCounting = true;
    }

    private void UpdateCounter()
    {
        if (m_isCounting)
        {
            if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "go.";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 1)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "1";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 2)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "2";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 3)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "3";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_totalTime - 4)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "4";
            }

        }
        else
        {
            m_lastTime = Time.timeSinceLevelLoad;
        }
    }
}
