using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

    private float m_rotationSpeed = 90f;
    private string m_rightStickX;

    public string RightStick
    {
        set { m_rightStickX = value; }
    }

	void Update () {

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
