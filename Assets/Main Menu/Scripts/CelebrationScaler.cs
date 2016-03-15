using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CelebrationScaler : ScoreAnnouncer {

    [SerializeField] private GameObject[] m_bars;
    [SerializeField] private Text[] m_scoreTexts;
    [SerializeField] private float m_celebrationTime = 4;

    private AllSkip m_allSkipper;

    private bool m_displayGameResult = true;

    private ScoreThing[] m_fetchedScoreThings;

    private float[] m_barScales;

    public float[] BarScales
    {
        set { m_barScales = value; }
    }

    public ScoreThing[] FetchedScoreThings
    {
        set { m_fetchedScoreThings = value; }
    }

    void Start()
    {
        m_allSkipper = GetComponent<AllSkip>();

        foreach (GameObject bar in m_bars)
        {
            bar.transform.localScale = new Vector3(1f, 0f, 1f);
        }
        StartCoroutine(DoneWithScores(m_celebrationTime));
    }

    public override void Update()
    {
        UpdateBars();
        DebugScoreThings();
        m_allSkipper.AllTeamsPressed(1, "GoToStaging");

    }

    private void DebugScoreThings()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //for (int i = 0; i < m_bars.Length; i++)
            //{
            //    Debug.Log("thing nr. " + i + " oldScore - " + m_fetchedScoreThings[i].oldScore);
            //    Debug.Log("thing nr. " + i + " newScore - " + m_fetchedScoreThings[i].newScore);
            //    Debug.Log("thing nr. " + i + " barScale - " + m_fetchedScoreThings[i].barScale);
            //    Debug.Log("thing nr. " + i + " teamName - " + m_fetchedScoreThings[i].teamName);
            //}
            TotalScores();
            m_displayGameResult = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
        }
    }

	private void UpdateBars ()
    {
        if (m_displayGameResult)
        {
            for (int i = 0; i < m_bars.Length; i++)
            {
                float yScale = Mathf.Clamp(m_bars[i].gameObject.transform.localScale.y + (4 * Time.deltaTime), 0, m_fetchedScoreThings[i].barScale);
                m_bars[i].gameObject.transform.localScale = new Vector3(1f, (0.1f + yScale), 1f);
                //m_bars[i].GetComponentInChildren<Image>().color = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>().PlayerColor;
            }
        }
    }

    private void TotalScores()
    {
        for (int i = 0; i < m_bars.Length; i++)
        {
            float yScale = Mathf.Clamp(m_bars[i].gameObject.transform.localScale.y + (4 * Time.deltaTime), 0, Mathf.InverseLerp(0,8,m_fetchedScoreThings[i].newScore));
            m_bars[i].gameObject.transform.localScale = new Vector3(.4f, (0.04f + yScale), .4f);
        }
    }

    private IEnumerator DoneWithScores(float time)
    {
        yield return new WaitForSeconds(time);
        GoToStaging();
    }

    public void GoToStaging()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
    }
}
