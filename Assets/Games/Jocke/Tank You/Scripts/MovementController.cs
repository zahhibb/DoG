using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    private Rigidbody m_rigid;
    private Transform m_direction;

    private float m_movementSpeed = 12f;
    private float m_rotationSpeed = 40f;
    private string m_leftStickX;
    private string m_triggerAxis;

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
        m_rigid = GetComponent<Rigidbody>();       
    }

	void Update () {
        
        // Accelerate
        if (Input.GetAxis(m_triggerAxis) < 0)
        {            
            m_rigid.AddForce(transform.TransformDirection(Vector3.forward) * m_movementSpeed);                    
        }

        // Reverse
        if (Input.GetAxis(m_triggerAxis) > 0)
        {
            m_rigid.AddForce(transform.TransformDirection(Vector3.back) * m_movementSpeed);
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
}
