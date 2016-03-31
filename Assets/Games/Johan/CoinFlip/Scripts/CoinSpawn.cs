using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawn : MonoBehaviour {

    [SerializeField]
    private Text m_teamWinText;
    [SerializeField]
    private CanvasGroup m_winCanvasGroup;

    public GameObject GreenCoin;
    public GameObject PinkCoin;
    public GameObject LemonCoin;
    public GameObject BlueCoin;

    [SerializeField]
    private int m_previousCoin;
    [SerializeField]
    private SpriteRenderer SpriteRend;

    GameObject m_gCoin;
    GameObject m_pCoin;
    GameObject m_lCoin;
    GameObject m_bCoin;
    private RotateCoin m_currentRotateCoin;

    private RotateCoin RotateCoin;

    private List<Manager> m_playerManagers;
    [SerializeField]
    private int m_playerAmount;

    private bool m_firstWin = false;
    private bool m_secondWin = false;
    private bool m_thirdWin = false;
    private bool m_fourthWin = false;

    private int m_currentWinner = -1;
    //Exempel public bool canRun { get { return m_canRun; } }
    private bool m_winner = false;
    public bool winner { get { return m_winner; } }

    [SerializeField]
    private float m_timer = 1.8f;
    [SerializeField]
    private float m_spawnTimer;

    [SerializeField]
    private float m_winTimer = 0.95f;
    [SerializeField]
    private bool m_showWinner = false;


    // Use this for initialization
    void Start ()
    {
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_playerAmount = player1Manager.Controllers;

        for (int i = 0; i < m_playerAmount; i++)
        {
            m_playerManagers.Add(GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>());
        }

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
            m_showWinner = false;
            m_winTimer = 0.95f;
            m_currentWinner = -1;
            Debug.Log("Space pressed");
            
        }

        foreach(Manager manager in m_playerManagers)
        {
            if (Input.GetButtonDown(manager.Inputs[0].name))
            {
                m_winner = false;
                m_showWinner = false;
                m_winTimer = 0.95f;
                m_currentWinner = -1;
                Debug.Log("Space pressed");

            }
        }

        //if (Input.GetButtonDown(m_playerManagers[0].Inputs[7].name))
        //{

        //}

        if (m_showWinner == true)
        {
            m_winTimer -= Time.deltaTime;

            if(m_winTimer <= 0f)
            {
                m_winCanvasGroup.alpha = 1f;
                
            }
        }
        if(m_showWinner == false)
        {
            m_winCanvasGroup.alpha = 0f;
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
            foreach (Manager manager in m_playerManagers)
            {
                if (Input.GetButtonDown(manager.Inputs[0].name))
                {
                    GoToCelebration();
                }
            }
        }
    }

    void SpawnCoin()
    {
       // GetComponent<CoinFlip>().
        var rand = Random.Range(0, m_playerAmount); //m_playerAmount;

        while (rand == m_previousCoin)
        {
            rand = Random.Range(0, m_playerAmount); //m_playerAmount;
        }

        if (rand == GetComponent<CoinFlip>().m_previousNumber && m_firstWin == false && m_secondWin == false && m_thirdWin == false && m_fourthWin == false)
        {
           

            m_currentWinner = GetComponent<CoinFlip>().m_previousNumber;

            m_winner = true;
            m_firstWin = true;
        }
    
        else if (rand == GetComponent<CoinFlip>().m_previousNumber1 &&  m_firstWin == true && m_secondWin == false && m_thirdWin == false && m_fourthWin == false)
        {
            m_currentWinner = GetComponent<CoinFlip>().m_previousNumber1;

            m_winner = true;
            m_secondWin = true;
            if(m_playerAmount == 2)
            {
                m_thirdWin = true;
                m_fourthWin = true;
            }
        }

        else if (rand == GetComponent<CoinFlip>().m_previousNumber2 && m_firstWin == true && m_secondWin == true && m_thirdWin == false && m_fourthWin == false)
        {
            m_currentWinner = GetComponent<CoinFlip>().m_previousNumber2;

            m_winner = true;
            m_thirdWin = true;

            if(m_playerAmount == 3)
            {
                m_fourthWin = true;
            }
        }

        else if (rand == GetComponent<CoinFlip>().m_coinValue && m_firstWin == true && m_secondWin == true && m_thirdWin == true && m_fourthWin == false)
        {
            m_currentWinner = GetComponent<CoinFlip>().m_coinValue;

            m_winner = true;
            m_fourthWin = true;
        }



        switch(m_currentWinner)
        {
            case 0:
                m_showWinner = true;
                m_teamWinText.text = "Pepper-Green Granola";
                m_teamWinText.color = ConvertColor(175, 239, 143);
                break;

            case 1:
                m_showWinner = true;
                m_teamWinText.text = "Pink-Pelican Parachute";
                m_teamWinText.color = ConvertColor(255, 168, 254);
                break;

            case 2:
                m_showWinner = true;
                m_teamWinText.text = "Lemon Truck";
                m_teamWinText.color = ConvertColor(234, 231, 94);
                break;

            case 3:
                m_showWinner = true;
                m_teamWinText.text = "Blue Coathanger";
                m_teamWinText.color = ConvertColor(125, 208, 255);
                break;
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

    private Color ConvertColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }
}
