using UnityEngine;
using System.Collections;

public class StayScaled : MonoBehaviour {

	[SerializeField] private Vector3 m_staticScale;
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.localScale = m_staticScale;

    }
}
