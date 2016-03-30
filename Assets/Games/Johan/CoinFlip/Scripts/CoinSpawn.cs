using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawn : MonoBehaviour {

    public GameObject GreenCoin;
    public GameObject PinkCoin;
    public GameObject LemonCoin;
    public GameObject BlueCoin;

    [SerializeField]
    private int m_previousCoin;

    GameObject m_gCoin;
    GameObject m_pCoin;
    GameObject m_lCoin;
    GameObject m_bCoin;
    private RotateCoin m_currentRotateCoin;

    private RotateCoin RotateCoin;

    private List<Manager> m_playerManagers;
    private int m_playerAmount;

    private bool m_firstWin = false;
    private bool m_secondWin = false;
    private bool m_thirdWin = false;
    private bool m_fourthWin = false;


    //Exempel public bool canRun { get { return m_canRun; } }
    private bool m_winner = false;
    public bool winner { get { return m_winner; } }

    [SerializeField]
    private float m_timer = 1.8f;
    [SerializeField]
    private float m_spawnTimer;


    // Use this for initialization
    void Start ()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_playerAmount = player1Manager.Controllers;



        m_spawnTimer = m_timer;
        SpawnCoin();
	}

    // Update is called once per frame
    void Update()
    {
        //if (m_gCoin == null && m_pCoin == null && m_lCoin == null && m_bCoin == null)
        //{
        //    if (m_canRun == true)
        //    {
        //        SpawnCoin();
        //        m_canRun = false;
        //        //Debug.Log(m_gCoin.transform.rotation.eulerAngles);
        //    }
        //}


        if (Input.GetKeyDown("space"))
        {
            m_winner = false;
            Debug.Log("Space pressed");
        }


            if (m_currentRotateCoin.rotate == true)  
            m_spawnTimer -= Time.deltaTime;
            if(m_spawnTimer <= 0f)
            {
                SpawnCoin();
                m_spawnTimer = m_timer;
            }


        if (m_firstWin == true && m_secondWin == true && m_thirdWin == true && m_fourthWin == true)
        {
            if (Input.GetKeyDown("space"))
            {
                GoToCelebration();
            }
        }
    }

    void SpawnCoin()
    {
       
       // GetComponent<CoinFlip>().
        var rand = Random.Range(0, 4); //m_playerAmount;

        while (rand == m_previousCoin)
        {
            rand = Random.Range(0, 4); //m_playerAmount;
        }

        if (rand == GetComponent<CoinFlip>().m_previousNumber && m_firstWin == false && m_secondWin == false && m_thirdWin == false && m_fourthWin == false)
        {
            m_winner = true;
            m_firstWin = true;
        }
    
        else if (rand == GetComponent<CoinFlip>().m_previousNumber1 &&  m_firstWin == true && m_secondWin == false && m_thirdWin == false && m_fourthWin == false)
        {
            m_winner = true;
            m_secondWin = true;
        }

        else if (rand == GetComponent<CoinFlip>().m_previousNumber2 && m_firstWin == true && m_secondWin == true && m_thirdWin == false && m_fourthWin == false)
        {
            m_winner = true;
            m_thirdWin = true;
        }

        else if (rand == GetComponent<CoinFlip>().m_coinValue && m_firstWin == true && m_secondWin == true && m_thirdWin == true && m_fourthWin == false)
        {
            m_winner = true;
            m_fourthWin = true;
        }






        switch (rand)
            {
        case 0:
                m_gCoin = Instantiate(GreenCoin, new Vector3(0, 0, 0), GreenCoin.transform.rotation) as GameObject;
                m_currentRotateCoin = m_gCoin.GetComponent<RotateCoin>();
                m_gCoin.transform.parent = transform;
                m_previousCoin = 0;
                break;

        case 1:
                m_pCoin = Instantiate(PinkCoin, new Vector3(0, 0, 0), PinkCoin.transform.rotation) as GameObject;
                m_currentRotateCoin = m_pCoin.GetComponent<RotateCoin>();
                m_pCoin.transform.parent = transform;
                m_previousCoin = 1;
                break;

         case 2:
                m_lCoin = Instantiate(LemonCoin, new Vector3(0, 0, 0), LemonCoin.transform.rotation) as GameObject;
                m_currentRotateCoin = m_lCoin.GetComponent<RotateCoin>();
                m_lCoin.transform.parent = transform;
                m_previousCoin = 2;
                break;

        case 3:
                m_bCoin = Instantiate(BlueCoin, new Vector3(0, 0, 0), BlueCoin.transform.rotation) as GameObject;
                m_currentRotateCoin = m_bCoin.GetComponent<RotateCoin>();
                m_bCoin.transform.parent = transform;
                m_previousCoin = 3;
                break;
            }
        
    }

    void GoToCelebration()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
        Debug.Log("Celebrate!!!");
    }
}
