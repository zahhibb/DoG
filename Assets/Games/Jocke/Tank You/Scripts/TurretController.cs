using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

    private float m_rotationSpeed = 100f;
	
	void Update () {

        // Rotate vehicle left
        if (Input.GetAxis("RightStickX_P1") < 0)
        {
            transform.Rotate(new Vector3(0, -m_rotationSpeed, 0) * Time.deltaTime);
        }

        // Rotate vehicle right
        if (Input.GetAxis("RightStickX_P1") > 0)
        {
            transform.Rotate(new Vector3(0, m_rotationSpeed, 0) * Time.deltaTime);
        }
    }
}
