using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneRouter : MonoBehaviour {

    [SerializeField] private string m_sceneChoice;
    [SerializeField] private float m_totalTime = 2f;
    [SerializeField] private GameObject m_countDownParent;
    [SerializeField] GameObject m_spinCountdown;
    [SerializeField] float m_spinCountdownTime = 3;
    [SerializeField] GameObject m_backgroundCutout;
    [SerializeField] GameObject m_background;
    [SerializeField] Color m_backgroundColor;

    private bool m_isCounting = false;
    private float m_lastTime = 0f;

    // serialize your very own tutorial here.
    //[SerializeField] Object m_sampleTutorial = null;
    //[SerializeField] Object m_floppyTutorial = null;
    //[SerializeField] Object m_aliensTutorial = null;
    //[SerializeField] Object m_tanksTutorial = null;
    [SerializeField] Object[] m_tutorialPrefabs = null;
    GameObject m_currentTutorial = null;

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
                Destroy(m_currentTutorial);
                StartCoroutine(TutorialTime(m_totalTime));
                SpinCountdown();
            }
            
        }
        UpdateCounter();

        AllSkipCheck();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneChoice);
        }
    }

    private void MakeTutorial(string choice)
    {
        switch (choice)
        {

            // and add a case for your game in this switch.
            case "Floppy1":
                GameObject floppyTutorial = (GameObject)Instantiate(m_tutorialPrefabs[1], transform.position, transform.rotation);
                m_totalTime = floppyTutorial.GetComponent<SelfDestruct>().LifeTime;
                StartCoroutine(TimeToStartSpin(m_totalTime));
                SpinCountdown();
                break;
            case "Aliens":
                GameObject aliensTutorial = (GameObject)Instantiate(m_tutorialPrefabs[2], transform.position, transform.rotation);
                m_totalTime = aliensTutorial.GetComponent<SelfDestruct>().LifeTime;
                StartCoroutine(TimeToStartSpin(m_totalTime));
                SpinCountdown();
                break;
            case "tanks_test":
                GameObject tanksTutorial = (GameObject)Instantiate(m_tutorialPrefabs[3], transform.position, transform.rotation);
                m_totalTime = tanksTutorial.GetComponent<SelfDestruct>().LifeTime;
                StartCoroutine(TimeToStartSpin(m_totalTime));
                SpinCountdown();
                break;
			case "Reaction Time":
			GameObject ReactionTimeTutorial = (GameObject)Instantiate(m_tutorialPrefabs[4],
				transform.position, transform.rotation);
			m_totalTime = ReactionTimeTutorial.GetComponent<SelfDestruct>().LifeTime;
			StartCoroutine(TimeToStartSpin(m_totalTime));
			SpinCountdown();
			break;
            case "SimulPress":
                GameObject simulTutorial = (GameObject)Instantiate(m_tutorialPrefabs[4], transform.position, transform.rotation);
                m_totalTime = simulTutorial.GetComponent<SelfDestruct>().LifeTime;
                StartCoroutine(TimeToStartSpin(m_totalTime));
                SpinCountdown();
                break;

            default:
                GameObject samplePrefab = (GameObject)Instantiate(m_tutorialPrefabs[4], transform.position, transform.rotation);
                m_totalTime = samplePrefab.GetComponent<SelfDestruct>().LifeTime;
                StartCoroutine(TimeToStartSpin(m_totalTime));
                SpinCountdown();
                break;
        }
        
       
    }

    private void StartScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    private IEnumerator TutorialTime(float time)
    {
        // add a little bit to finish animating :/
        time += 0.8f;
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneChoice);
    }

    private IEnumerator TimeToStartSpin(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(TutorialTime(m_spinCountdownTime));
        SpinCountdown();
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
            //Debug.Log("time since lastTime: " + (Time.timeSinceLevelLoad - m_lastTime));

            if (Time.timeSinceLevelLoad - m_lastTime >= m_spinCountdownTime + m_totalTime)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "ready";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_spinCountdownTime + m_totalTime - 1)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "get set";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_spinCountdownTime + m_totalTime - 2)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "on your marks";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_spinCountdownTime + m_totalTime - 3)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "game starting";
            }
            else if (Time.timeSinceLevelLoad - m_lastTime >= m_spinCountdownTime + m_totalTime - 4)
            {
                m_countDownParent.GetComponentInChildren<Text>().text = "game starting";
            }

        }
        else
        {
            m_lastTime = Time.timeSinceLevelLoad;
        }
    }

    private void AllSkipCheck()
    {
        if (gameObject.GetComponent<AllSkip>())
        {
            //Debug.Log(gameObject.name + " found allskipper");
            gameObject.GetComponent<AllSkip>().AllTeamsPressed(7, "SpinCountdown");
            //Debug.Log("DoneToStaging called DoneInMainMenu from All");
        }
    }
}
