using UnityEngine;
using System.Collections;

public class collisionShot : MonoBehaviour {
    bool shallDestroy;//not instant destruction
	// Use this for initialization
	void Start () {
        shallDestroy = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (shallDestroy)
        {
            Destroy(gameObject);
        }
        else if ((transform.position.x < -32)
            || (transform.position.x > Screen.width + 32)
            || (transform.position.y < -32)
            || (transform.position.y > Screen.height + 32))
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionTrigger()
    {
        shallDestroy = true;
    }
}
