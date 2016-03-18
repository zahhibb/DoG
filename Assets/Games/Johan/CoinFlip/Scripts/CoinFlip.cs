using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinFlip : MonoBehaviour {
    [SerializeField]
    private int m_coinValue;
    [SerializeField]
    private int m_playerAmount;
    [SerializeField]
    private int m_currentScore = 8;
    [SerializeField]
    private int m_rolls;
    private List<Manager> m_playerManagers;
    [SerializeField]
    private int m_previousNumber = -1;
    [SerializeField]
    private int m_previousNumber1 = -1;
    [SerializeField]
    private int m_previousNumber2 = -1;

    private bool m_canFlip = true;

    // Use this for initialization
    void Start () 
    {

        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_playerAmount = player1Manager.Controllers;

        // glöm ej att ta bort denna skit
        m_playerManagers.Add(player1Manager);
        m_playerManagers.Add(player1Manager);
        m_playerManagers.Add(player1Manager);
        m_playerManagers.Add(player1Manager);

       
        
            
            FlipCoin();
        
    }
	
	// Update is called once per frame
	void Update () 
    {

	}


    void FlipCoin()
    {
        if (m_canFlip == true)
        {
            while (m_coinValue == m_previousNumber || m_coinValue == m_previousNumber1 || m_coinValue == m_previousNumber2)
            {
                m_coinValue = Random.Range(0, 4);
            }

            if (m_rolls == 0)
            {
                m_previousNumber = m_coinValue;
            }

            else if (m_rolls == 1)
            {
                m_previousNumber1 = m_coinValue;
            }

            else if (m_rolls == 2)
            {
                m_previousNumber2 = m_coinValue;
            }
           

            switch (m_coinValue)
            {
                case 0:
                    m_rolls++;
                    Debug.Log("0");
                    GreenGranolaWin();

                    break;

                case 1:
                    m_rolls++;
                    Debug.Log("1");
                    PinkPelicanWin();

                    break;

                case 2:
                    Debug.Log("2");
                    m_rolls++;
                    LemonTruckWin();

                    break;

                case 3:
                    Debug.Log("3");
                    m_rolls++;
                    BlueCoatHangerWin();

                    break;
            }
        }
    }

    void GreenGranolaWin()
    {
        m_playerManagers[0].Score += m_currentScore;
        
        m_currentScore /= 2;
        if (m_rolls == 4)
        {
            m_canFlip = false;
            GoToCelebration();
        }

        FlipCoin();
    }

    void PinkPelicanWin()
    {
        m_playerManagers[1].Score += m_currentScore;
        
        m_currentScore /= 2;
        if (m_rolls == 4)
        {
            m_canFlip = false;
            GoToCelebration();
        }

        FlipCoin();
    }

    void LemonTruckWin()
    {
        m_playerManagers[2].Score += m_currentScore;
        
        m_currentScore /= 2;
        if (m_rolls == 4)
        {
            m_canFlip = false;
            GoToCelebration();
        }

        FlipCoin();
    }

    void BlueCoatHangerWin()
    {
        m_playerManagers[3].Score += m_currentScore;
        
        m_currentScore /= 2;
        if (m_rolls == 4)
        {
            m_canFlip = false;
            GoToCelebration();
        }

        FlipCoin();
    }

    void GoToCelebration()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
    }
}