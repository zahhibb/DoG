using UnityEngine;
using System.Collections;

public class WheelMaker : MonoBehaviour {

    [SerializeField] private Object m_wheelBit = null;
    [SerializeField] private int m_segments;
    [SerializeField] private float m_squareSize;

    void Start ()
    {
	    for (int i = 0; i > m_segments; i++)
        {
            GameObject segment = (GameObject)Instantiate(m_wheelBit, gameObject.transform.position, gameObject.transform.rotation);
            segment.gameObject.transform.position += new Vector3(0, m_squareSize * (Mathf.Sqrt(2)), 0);
            segment.gameObject.transform.eulerAngles += new Vector3( 0, 0, 45);
            //segment.gameObject.transform.localScale.y

        }
	}
	

	void Update ()
    {
	
	}
}
