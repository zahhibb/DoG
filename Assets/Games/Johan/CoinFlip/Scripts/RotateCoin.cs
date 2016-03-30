using UnityEngine;
using System.Collections;




public class RotateCoin : MonoBehaviour {
    [SerializeField]
    private int m_rotationSpeed = -200;
    [SerializeField]
    private float m_destroyTimer = 1;

    private CoinSpawn CoinSpawn;
    private CoinFlip flip;

    private bool m_rotate = true;
    public bool rotate { get { return m_rotate; } }

    // Use this for initialization
    void Start ()
    {
        CoinSpawn = GetComponentInParent<CoinSpawn>();
        flip = GetComponentInParent<CoinFlip>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            m_rotate = true; 
            Debug.Log("Space2 pressed");
        }

        if (CoinSpawn.winner == true)
        {
            if (transform.rotation.eulerAngles.x >= 268 && transform.rotation.eulerAngles.x <= 272)
            {
                m_rotate = false;
            }

        }

        if (m_rotate == true)
        {
            m_destroyTimer -= Time.deltaTime;
            //transform.Rotate(Time.deltaTime * m_rotationSpeed, 0, 0);
            transform.Rotate(new Vector3(m_rotationSpeed, 0, 0) * Time.deltaTime);
        }
            if (m_destroyTimer <= 0)
            {
                if (transform.rotation.eulerAngles.x >= 88 && transform.rotation.eulerAngles.x <= 92)
                {
                    Destroy(gameObject);
                    //Debug.Log(transform.rotation.eulerAngles.x);
                }

            }
        
    }
}
