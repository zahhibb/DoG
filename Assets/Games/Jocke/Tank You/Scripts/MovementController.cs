using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    private Rigidbody m_rigid;
    private Transform m_direction;

    private float m_movementSpeed = 13f; // The speed of how fast the tank moves
    private float m_rotationSpeed = 40f; // The speed of how fast the tank rotates
    private string m_leftStickX;
    private string m_triggerAxis;

    private Manager m_myManager;

    public Manager MyManager
    {
        get { return m_myManager; }
        set { m_myManager = value; }
    }

    public string LeftStickX
    {
        set { m_leftStickX = value; }
    }

    public string TriggerAxis
    {
        set { m_triggerAxis = value; }
    }

    void Start()
    {                
        m_rigid = GetComponentInParent<Rigidbody>();

        m_triggerAxis = m_myManager.Inputs[16].name;
        m_leftStickX = m_myManager.Inputs[12].name;
    }

	void FixedUpdate ()
    {
        TankMovement();        
    }

    // Movement and rotation for the tanks
    private void TankMovement()
    {
        // Accelerate
        if (Input.GetAxis(m_triggerAxis) < 0)
        {
            m_rigid.AddForce(transform.TransformDirection(Vector3.right) * m_movementSpeed);
        }

        // Reverse
        if (Input.GetAxis(m_triggerAxis) > 0)
        {
            m_rigid.AddForce(transform.TransformDirection(Vector3.left) * m_movementSpeed);
        }

        // Rotate vehicle left
        if (Input.GetAxis(m_leftStickX) < 0)
        {
            transform.Rotate(new Vector3(0, -m_rotationSpeed, 0) * Time.deltaTime);
        }

        // Rotate vehicle right
        if (Input.GetAxis(m_leftStickX) > 0)
        {
            transform.Rotate(new Vector3(0, m_rotationSpeed, 0) * Time.deltaTime);
        }
    }

    public void SetScore(int score)
    {
        m_myManager.Score += score;
    }
}
