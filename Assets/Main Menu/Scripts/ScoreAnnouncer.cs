using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreAnnouncer : MonoBehaviour {

    private ScoreThing[] m_scoreThings;
    private Manager m_manager1;
    private GameObject m_celebrationCanvas;
    private Text[] m_scoreTexts;

    private void Start()
    {
        m_scoreThings = new ScoreThing[4];
        GetOldScores();
        DontDestroyOnLoad(gameObject);
        Debug.Log("Start called in " + gameObject.name + ", 'Im ready to accounce some scores!'");
    }

    public virtual void Update() // OnLevelWasLoaded snarare?
    {
        GetNewScores();
        SetBarScales();
        DebugScoreThings();
    }

    private void GetOldScores()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            Manager manager = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>();
            m_scoreThings[i].oldScore = manager.Score;
            m_scoreThings[i].teamName = manager.TeamName;
        }
    }

    private void GetNewScores()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            Manager manager = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>();
            m_scoreThings[i].newScore = manager.Score;
            m_scoreThings[i].barScale = (m_scoreThings[i].newScore - m_scoreThings[i].oldScore);
        }
    }

    private void SetBarScales()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            ScoreThing current = m_scoreThings[i];
            current.barScale = current.newScore - current.oldScore;

            SendToScaler();
            
        }
    }

    private void SendToScaler()
    {
        if (GameObject.FindGameObjectWithTag("CelebratorCanvas"))
        {
            GameObject.FindGameObjectWithTag("CelebratorCanvas").GetComponent<CelebrationScaler>().FetchedScoreThings = m_scoreThings;
            Debug.Log(gameObject.name + " is sending Score and things ");
            Destroy(gameObject);
        }

    }
    private void DebugScoreThings()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("thing nr. " + i + " oldScore - " + m_scoreThings[i].oldScore);
                Debug.Log("thing nr. " + i + " newScore - " + m_scoreThings[i].newScore);
                Debug.Log("thing nr. " + i + " barScale - " + m_scoreThings[i].barScale);
                Debug.Log("thing nr. " + i + " teamName - " + m_scoreThings[i].teamName);
            }
        }
    }

    public struct ScoreThing
    {
        public int oldScore;
        public int newScore;
        public string teamName;
        public float barScale;
    }
}
