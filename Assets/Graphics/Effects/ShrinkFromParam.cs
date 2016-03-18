using UnityEngine;
using System.Collections;

public class ShrinkFromParam : MonoBehaviour
{

    private Vector3 m_originalScale;

    private void Start()
    {
        m_originalScale = gameObject.transform.localScale;
    }

    private void Update()
    {

        gameObject.transform.localScale = m_originalScale / (Mathf.Clamp(Mathf.Abs((transform.root.GetComponentInChildren<Rotate>().ZRot / 10)), 1, 30)); 
    }

}
