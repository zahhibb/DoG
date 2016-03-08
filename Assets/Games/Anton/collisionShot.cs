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
        {//destroys the object if it has collided with a player since last frame
            Destroy(gameObject);
        }
        else if ((transform.position.x < -32)
            || (transform.position.x > Screen.width + 32)
            || (transform.position.y < -32)
            || (transform.position.y > Screen.height + 32))
        {//or if it is outside of bounds
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {//destroys the shot if it collides with a player
        shallDestroy = true;
        if (collision.gameObject.tag == "Player")
        {//doing instant kill right now, keeps up the speed and makes the code simple
            //used http://answers.unity3d.com/questions/124126/how-to-make-a-player-die-on-collision.html for inspiration
            Destroy(collision.gameObject);
        }
    }
}
