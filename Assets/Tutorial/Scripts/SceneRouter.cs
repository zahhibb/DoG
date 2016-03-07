using UnityEngine;
using System.Collections;

public class SceneRouter : MonoBehaviour {

    private string m_sceneChoice;
    private float m_totalTime = 2f;

    // serialize your very own tutorial here.

    [SerializeField] Object m_sampleTutorial = null;

	private void Start ()
    {
        m_sceneChoice = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().ChosenScene;
        MakeTutorial(m_sceneChoice);

        // there should be some fancy count down animated too
        StartCoroutine(CountDown(m_totalTime));
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
}
