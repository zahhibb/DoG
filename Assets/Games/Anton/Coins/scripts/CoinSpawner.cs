using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	

    float m_currentTime;//used to measure the time since last shot
    float m_startVelocity;
    float m_timeBetweenCoins;//the firing speed, set rather high as it will decrease
    float m_turning;
    [SerializeField]
    GameObject m_coin;//is set inside the Unity Engine
                      // Use this for initialization
    void Start()
    {


        m_turning = 0;//the amount of degrees the player has turned
        m_currentTime = 0;
        m_timeBetweenCoins = 2.3f;
        m_startVelocity = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;//adds the number of time since last coin
        if (m_currentTime > m_timeBetweenCoins)//checks if enough time has passed
        {
            m_currentTime -= m_timeBetweenCoins;//decreased by the time since last coin
            if (m_timeBetweenCoins > 0.35)//increases the firing speed with a maximum firing speed at 1/0.35 shots per second (almost 3 shots per second)
            {
                m_timeBetweenCoins -= 0.05f;
            }
            GameObject newCoin = (GameObject)Instantiate(m_coin, transform.position, transform.rotation);//sets it to the same position and rotation 
            newCoin.GetComponent<Rigidbody2D>().AddForce(m_startVelocity * -1 * transform.up);
            //sets the velocity indirectly by adding a force
            if (m_turning < 90)
            {
                transform.Rotate(Vector3.forward, 35);
                m_turning += 15;
            }
            else
            {
                transform.Rotate(Vector3.forward, 180);
                m_turning = -90;
            }
        }
    }
}
