using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int m_playerNumber;
    private Manager m_myManager;

    private bool m_isXAxisInUse = false;
    private bool m_isStickAxisInUse = false;

    // Use this for initialization
    void Start ()
    {
        m_myManager = GameObject.FindGameObjectWithTag("ManagerP" + m_playerNumber).GetComponent<Manager>();
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
            Debug.Log("Manager: " + m_myManager.tag  + " > " + m_myManager.Inputs[0].name);
        }


            if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetButtonDown(m_myManager.Inputs[5].name))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if (Input.GetAxisRaw("DPadY_P2") == 0)
        {
            m_isXAxisInUse = false;
        }


        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //Time.timeScale = 1;
        }

        if (Input.GetButtonDown(m_myManager.Inputs[4].name))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }


        // New for DPad inputs.

        if (Input.GetAxisRaw(m_myManager.Inputs[10].name) >= 0.5f)
        {
            if (m_isXAxisInUse == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                m_isXAxisInUse = false;
            }
        }

        if (Input.GetAxisRaw(m_myManager.Inputs[10].name) <= -0.5f)
        {
            if (m_isXAxisInUse == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                m_isXAxisInUse = false;
            }
        }

        if (Input.GetAxisRaw(m_myManager.Inputs[12].name) >= 0.5f)
        {
            if (m_isStickAxisInUse == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                m_isStickAxisInUse = false;
            }
        }

        if (Input.GetAxisRaw(m_myManager.Inputs[12].name) <= -0.5f)
        {
            if (m_isStickAxisInUse == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                m_isStickAxisInUse = false;
            }
        }

        // this whole "inUse" thing is maybe not needed, Aurthur's choice ( mispunning intended :U )

        if (Input.GetAxisRaw(m_myManager.Inputs[10].name) == 0)
        {
            m_isXAxisInUse = false;
        }

        if (Input.GetAxisRaw(m_myManager.Inputs[12].name) == 0f)
        {
            m_isStickAxisInUse = false;
        }



        // End of New for DPad inputs.
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
