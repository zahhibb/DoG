using UnityEngine;
using System.Collections;

public class TrackPosition : MonoBehaviour {

    [SerializeField] GameObject m_trackTarget;	

	void Update ()
    {
        gameObject.transform.position = m_trackTarget.gameObject.transform.position;
	}
}
