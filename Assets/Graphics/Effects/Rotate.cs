using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField] private float m_xRot = 0;
    [SerializeField] private float m_yRot = 0;
    [SerializeField] private float m_zRot = 0;

    private void Update ()
    {
        Vector3 rotation = new Vector3(m_xRot, m_yRot, m_zRot);
        transform.Rotate(rotation * Time.deltaTime);
	}

    public float XRot
    {
        set { m_xRot = value; }
        get { return m_xRot; }
    }
    public float YRot
    {
        set { m_yRot = value; }
        get { return m_yRot; }
    }
    public float ZRot
    {
        set { m_zRot = value; }
        get { return m_zRot; }
    }
}
