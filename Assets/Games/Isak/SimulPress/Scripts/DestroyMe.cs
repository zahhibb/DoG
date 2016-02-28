using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DestroyMe : MonoBehaviour
{
	public void Destroy()
    {
        Destroy(gameObject);
        //Send the message to the collector
	}
}
