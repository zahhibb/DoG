using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    private float m_movementSpeed = 15f;
    private float m_rotationSpeed = 50f;

    private Rigidbody m_rigid;

    private Transform m_direction;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        
    }

	void Update () {
        
        // Accelerate
        if (Input.GetAxis("RightTriggerAxis_P1") > 0)
        {            
            m_rigid.AddForce(transform.TransformDirection(Vector3.forward) * m_movementSpeed);                    
        }

        // Reverse
        if (Input.GetAxis("LeftTriggerAxis_P1") > 0)
        {
            m_rigid.AddForce(transform.TransformDirection(Vector3.back) * m_movementSpeed);
        }

        // Rotate vehicle left
        if (Input.GetAxis("LeftStickX_P1") < 0)
        {
            transform.Rotate(new Vector3(0, -m_rotationSpeed, 0) * Time.deltaTime);
        }

        // Rotate vehicle right
        if (Input.GetAxis("LeftStickX_P1") > 0)
        {
            transform.Rotate(new Vector3(0, m_rotationSpeed, 0) * Time.deltaTime);
        }
        
    }
}
