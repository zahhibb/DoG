using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

    [SerializeField] bool m_beShrinking = false; 

	void Update ()
    {
	    if (m_beShrinking)
        {
            gameObject.transform.localScale *= (1 - (5 * Time.deltaTime));
        }
	}
}
