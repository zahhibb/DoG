using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelCreator : MonoBehaviour {

    [SerializeField] GameObject m_tile;

    private List<GameObject> m_tileList = new List<GameObject>();    

    void Start()
    {
        for (int i = 0; i < 28; i++)
        {
            for (int k = 0; k < 12; k++)
            {
                GameObject newTile = (GameObject)Instantiate(m_tile, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - k), transform.rotation);
                m_tileList.Add(newTile);                
            }
        }
    }

    void Update()
    {

    }
}
