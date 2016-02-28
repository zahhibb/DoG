using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField] private float m_xRot = 0;
    [SerializeField] private float m_yRot = 0;
    [SerializeField] private float m_zRot = 0;

    void Update ()
    {
        Vector3 rotation = new Vector3(m_xRot, m_yRot, m_zRot);
        transform.Rotate(rotation * Time.deltaTime);
	}
}
