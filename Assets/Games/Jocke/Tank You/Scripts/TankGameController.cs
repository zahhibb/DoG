using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TankGameController : MonoBehaviour
{
    [SerializeField] private Transform[] m_swiperStartPos = new Transform[1];
    [SerializeField] private Transform[] m_swiperTargetPos = new Transform[1];
    [SerializeField] private GameObject[] m_suddenDeathSwipers = new GameObject[2];
    [SerializeField] private GameObject[] m_spawnLoc = new GameObject[4];
    [SerializeField] private List<GameObject> m_teamTanks;
    [SerializeField] private GameObject m_tankArena;
    [SerializeField] private CanvasGroup m_winCanvasGroup;
    [SerializeField] private Text m_teamWinText;
    [SerializeField] private Text m_suddenDeathText;            

    private List<Manager> m_playerManagers;
    private Manager m_manager;
    private int m_settingScore = 0;
    private float m_suddenDeathCountdown = 10f;
    private float m_swiperSpeed = 1.0f;
    private float m_startTime;


    void Start ()
    {        
        CreateTeams();
        
        m_settingScore = 5 - m_playerManagers[0].Controllers;

        
    }
	
	void Update ()
    {
        SuddenDeath();

        GameEnd();        
    }

    private void SuddenDeath()
    {
        if (m_suddenDeathCountdown > 1)
        {
            m_suddenDeathCountdown -= Time.deltaTime;

            int seconds = Mathf.FloorToInt(m_suddenDeathCountdown);
            string formatTime = string.Format("{00}", seconds);

            m_suddenDeathText.text = formatTime;

            m_startTime = Time.time;
        }
        else
        {
            m_suddenDeathText.text = null;
            m_suddenDeathText.transform.parent.gameObject.SetActive(false);

            /*
                Set UI panel of "SUDDEN DEATH" to active/visible.
            */

            foreach (GameObject swiper in m_suddenDeathSwipers)
            {
                swiper.SetActive(true);
            }

            for (int i = 0; i < m_suddenDeathSwipers.Length; i++)
            {
                float swiperJourneyLength = Vector3.Distance(m_swiperStartPos[i].position, m_swiperTargetPos[i].position);

                float distCovered = (Time.time - m_startTime) * m_swiperSpeed;
                float fracJourney = distCovered / swiperJourneyLength;

                m_suddenDeathSwipers[i].transform.position = Vector3.Lerp(m_swiperStartPos[i].position, m_swiperTargetPos[i].position, fracJourney);

                if ()
                {

                }
            }
        }
    }

    // Displays which team who won and reroutes to Score & Celebration coroutine
    private void GameEnd()
    {
        if (m_playerManagers.Count <= 1)
        {
            StartCoroutine(LastManStanding());

            m_winCanvasGroup.alpha = 1f;

            if (m_teamWinText != null)
            {
                switch (m_playerManagers[0].ToString())
                {
                    case "Team 1 Manager (Manager)":
                        m_teamWinText.text = "Pepper-Green Granola";
                        m_teamWinText.color = ConvertColor(175, 239, 143);
                        break;
                    case "Team 2 Manager (Manager)":
                        m_teamWinText.text = "Pink-Pelican Parachute";
                        m_teamWinText.color = ConvertColor(255, 168, 254);
                        break;
                    case "Team 3 Manager (Manager)":
                        m_teamWinText.text = "Lemon Truck";
                        m_teamWinText.color = ConvertColor(234, 231, 94);
                        break;
                    case "Team 4 Manager (Manager)":
                        m_teamWinText.text = "Blue Coathanger";
                        m_teamWinText.color = ConvertColor(125, 208, 255);
                        break;
                    default:
                        Debug.Log("Something went wrong with winning text!");
                        break;
                }
            }
        }
    }

    // Sets score for last player and loads end game celebration
    private IEnumerator LastManStanding()
    {
        yield return new WaitForSeconds(3f);

        if (m_playerManagers.Count > 0)
        {
            m_playerManagers[0].Score += m_settingScore;
        }
        
        SceneManager.LoadScene("Celebration");
    }

    // Converts color from RGB to Unity applicable RGB
    private Color ConvertColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

    // Creates managers and spawns a tank for each team
    private void CreateTeams()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();

        int playerCount = player1Manager.Controllers;        

        for (int i = 0; i < player1Manager.Controllers; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());

            GameObject player = (GameObject)Instantiate(m_teamTanks[i], new Vector3(m_spawnLoc[i].transform.position.x, m_spawnLoc[i].transform.position.y, m_spawnLoc[i].transform.position.z),
                m_spawnLoc[i].transform.rotation);

            player.GetComponentInChildren<MovementController>().MyManager = m_playerManagers[i];
        }
    }

    // Destroys player tanks if they fall below the arena and into the trigger.
    // Sets score for each player defeated.
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInChildren<MovementController>().SetScore(m_settingScore);                       
            m_settingScore = m_settingScore * 2;

            m_playerManagers.Remove(col.gameObject.GetComponentInChildren<MovementController>().MyManager);
            Destroy(col.gameObject);            
        }
    }
}
