using UnityEngine;
using System.Collections;

public class ScoreAnnouncer : MonoBehaviour {

    private ScoreThing[] m_scoreThings;
    private Manager m_manager1;
    private GameObject m_celebrationCanvas;

	void Start ()
    {
        m_celebrationCanvas = GameObject.FindGameObjectWithTag("CelebratorCanvas");
        //m_manager1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        //m_scoreThings = new ScoreThing[m_manager1.Controllers];
        m_scoreThings = new ScoreThing[4];
    }

    private void GetOldScores()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            m_scoreThings[i].oldScore = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>().Score;
        }
    }

    private void GetNewScores()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            m_scoreThings[i].oldScore = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>().Score;
        }
    }

    private void SetBarScales()
    {
        for (int i = 0; i < m_scoreThings.Length; i++)
        {
            ScoreThing current = m_scoreThings[i];
            current.barScale = current.newScore - current.oldScore;

            if (m_celebrationCanvas)
            {
                CelebrationScaler scaler = m_celebrationCanvas.GetComponent<CelebrationScaler>();
            }
        }
    }

    struct ScoreThing
    {
        public int oldScore;
        public int newScore;
        public string teamName;
        public float barScale;
    }
}
