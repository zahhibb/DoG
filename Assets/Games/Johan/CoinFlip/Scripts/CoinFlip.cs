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

    // Use this for initialization
    void Start () 
    {
        
        m_playerManagers = new List<Manager>();
        Manager player1Manager = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_playerAmount = player1Manager.Controllers;

        FlipCoin();
    }
	
	// Update is called once per frame
	void Update () 
    {

	}


    void FlipCoin()
    {
        if(m_rolls == m_playerAmount - 1)
        {
            GoToCelebration();
        }

        while (m_coinValue == m_previousNumber || m_coinValue == m_previousNumber1 || m_coinValue == m_previousNumber2)
        {
            m_coinValue = Random.Range(0, m_playerAmount);
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
              GreenGranolaWin();
                m_rolls++;
                break;

            case 1:
                PinkPelicanWin();
                m_rolls++;
                break;

            case 2:
               LemonTruckWin();
                m_rolls++;
                break;

            case 3:
                BlueCoatHangerWin();
                m_rolls++;
                break;
        }
    }

    void GreenGranolaWin()
    {
        m_playerManagers[0].Score += m_currentScore;

        m_currentScore /= 2;
        FlipCoin();
    }

    void PinkPelicanWin()
    {
        m_playerManagers[1].Score += m_currentScore;

        m_currentScore /= 2;
        FlipCoin();
    }

    void LemonTruckWin()
    {
        m_playerManagers[2].Score += m_currentScore;

        m_currentScore /= 2;
        FlipCoin();
    }

    void BlueCoatHangerWin()
    {
        m_playerManagers[3].Score += m_currentScore;

        m_currentScore /= 2;
        FlipCoin();
    }

    void GoToCelebration()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Celebration");
    }
}