using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int m_playerNumber;
    private Manager m_myManager;

    // Use this for initialization
    void Start ()
    {
        Manager m_myManager = GameObject.FindGameObjectWithTag("ManagerP" + m_playerNumber).GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            //Time.timeScale = 1;
        }

        if (Input.GetButtonDown(m_myManager.Inputs[0].name))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            //Time.timeScale = 1;
        }


        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetButtonDown(m_myManager.Inputs[5].name))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //Time.timeScale = 1;
        }


        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //Time.timeScale = 1;
        }
        if (Input.GetButtonDown(m_myManager.Inputs[4].name))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //Time.timeScale = 1;
        }


    }

    public Manager MyManager
        {
        set { m_myManager = value; }
        get { return m_myManager; }

        }
    public int PlayerNumber
        {
        set { m_playerNumber = value; }
        get { return m_playerNumber; }
        }

}
