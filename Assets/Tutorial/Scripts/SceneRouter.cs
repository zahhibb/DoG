using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneRouter : MonoBehaviour {

    [SerializeField] private string m_sceneChoice;
    [SerializeField] private float m_totalTime = 2f;
    [SerializeField] private Canvas m_countDownCanvas;
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
        StartCoroutine(CountDown(m_totalTime));
        SpinCountdown();
    }

    private void Update()
    {
        if (m_isCounting)
        {
            if (Time.timeSinceLevelLoad - m_lastTime >= 3)
            {
                m_countDownCanvas.GetComponentInChildren<Text>().text = "go.";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= 2)
            {
                m_countDownCanvas.GetComponentInChildren<Text>().text = "1";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= 1)
            {
                m_countDownCanvas.GetComponentInChildren<Text>().text = "2";
            }
        }
        else
        {
            m_lastTime = Time.timeSinceLevelLoad;
        }
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

    private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneChoice);
    }

    private void SpinCountdown()
    {
        m_countDownCanvas.GetComponentInChildren<Text>().text = "3";
        m_countDownCanvas.GetComponentInChildren<PlayImage>().PlayLoop();
        m_isCounting = true;
    }


}
