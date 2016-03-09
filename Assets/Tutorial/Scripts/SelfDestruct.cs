using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{

	[SerializeField] private float m_lifeTime = 5;
    [SerializeField] private bool startOnLoad = false;


    private void Start ()
	{	
		StartCoroutine(CountDown(m_lifeTime));
	}

    private IEnumerator CountDown(float time)
	{
			yield return new WaitForSeconds(time);
			Destroy(gameObject);
	}

    public float LifeTime
    {
        set { m_lifeTime = value; }
        get { return m_lifeTime; }
    }

}

