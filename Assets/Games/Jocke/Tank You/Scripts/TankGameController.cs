using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TankGameController : MonoBehaviour {

    [SerializeField] private GameObject[] m_spawnLoc = new GameObject[4];
    [SerializeField] private List<GameObject> m_teamTanks;

    private List<Manager> m_playerManagers;
    private Manager m_manager;
    private int m_settingScore;

    [SerializeField] private Text m_playerCountText;


	void Start () {        

        CreateTeams();

        m_settingScore = 5 - m_playerManagers[0].Controllers;
    }	
	
	void Update () {

        if (m_playerCountText != null)
        {
            m_playerCountText.text = m_playerManagers.Count.ToString();
        }

        if (m_playerManagers.Count <= 1)
        {
            StartCoroutine(LastManStanding());
        } 
    }

    private IEnumerator LastManStanding()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Celebration");
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

    private void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInChildren<MovementController>().SetScore(m_settingScore);
            
            Debug.Log("Manager number " + col.gameObject.GetComponentInChildren<MovementController>().MyManager.TeamNumber + " was awarded " + m_settingScore);

            m_settingScore = m_settingScore * 2;            

            m_playerManagers.Remove(col.gameObject.GetComponentInChildren<MovementController>().MyManager);
            Destroy(col.gameObject);

            // Set score for last man standing
            m_playerManagers[0].Score += m_settingScore;
        }
    }    
}
