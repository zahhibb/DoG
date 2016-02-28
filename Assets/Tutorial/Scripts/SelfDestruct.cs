using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{

	[SerializeField] private float m_lifeTime = 10.0f;
	
	private void Start ()
	{	
		StartCoroutine(CountDown(m_lifeTime));
	}

    private IEnumerator CountDown(float time)
	{
			yield return new WaitForSeconds(time);
			Destroy(gameObject);
	}

}

