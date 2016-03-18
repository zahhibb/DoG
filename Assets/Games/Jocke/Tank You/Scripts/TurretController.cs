using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

    private float m_rotationSpeed = 90f; // The speed of how fast the turret rotates
    private string m_rightStickX;

    public string RightStick
    {
        set { m_rightStickX = value; }
    }

    void Start()
    {
        m_rightStickX = transform.root.GetComponentInChildren<MovementController>().MyManager.Inputs[14].name;
    }

	void Update () {
        RotateTankTurret();        
    }

    // Rotation of the tanks turrets
    private void RotateTankTurret()
    {
        // Rotate vehicle left
        if (Input.GetAxis(m_rightStickX) < 0)
        {
            transform.Rotate(new Vector3(0, -m_rotationSpeed, 0) * Time.deltaTime);
        }

        // Rotate vehicle right
        if (Input.GetAxis(m_rightStickX) > 0)
        {
            transform.Rotate(new Vector3(0, m_rotationSpeed, 0) * Time.deltaTime);
        }
    }
}
