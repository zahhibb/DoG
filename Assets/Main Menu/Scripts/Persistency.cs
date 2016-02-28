using UnityEngine;
using System.Collections;

public class Persistency : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
