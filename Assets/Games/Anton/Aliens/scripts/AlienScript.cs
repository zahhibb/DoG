using UnityEngine;
using System.Collections;
public class AlienScript : MonoBehaviour {
    float m_currentTime;//used to measure the time since last shot
    float m_timeBetweenShots;//the firing speed, set rather high as it will decrease
    float m_startVelocity;//the speed of the bullets as they spawn
    float m_turning;
    [SerializeField]
    GameObject m_shot;//is set inside the Unity Engine
	// Use this for initialization
	void Start ()
    {
        

        m_turning = 0;//the amount of degrees the player has turned
        m_currentTime = 0;
        m_timeBetweenShots = 2.8f;
        m_startVelocity = 30.0f;
    }
	
	// Update is called once per frame
	void Update () {
        m_currentTime += Time.deltaTime;//adds the number of time since last shot
        if (m_currentTime > m_timeBetweenShots)//checks if enough time has passed
        {
            m_currentTime -= m_timeBetweenShots;//decreased by the time since last shot
            if (m_timeBetweenShots > 0.25)//increases the firing speed with a maximum firing speed at 1/0.15 shots per second (6 2/3)
            {
                m_timeBetweenShots -= 0.1f;
            }
            GameObject newShot = (GameObject)Instantiate(m_shot, transform.position, transform.rotation);//sets it to the same position and rotation 
            newShot.GetComponent<Rigidbody2D>().AddForce(m_startVelocity * -1 * transform.up);
            //sets the velocity indirectly by adding a force
            if (m_turning < 90)
            {
                transform.Rotate(Vector3.forward, 30);
                m_turning += 30;
            }
            else
            {
                transform.Rotate(Vector3.forward, 180);
                m_turning = -90;
            }
        }
	}
}
