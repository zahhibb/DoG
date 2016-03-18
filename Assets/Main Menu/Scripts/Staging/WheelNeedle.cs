using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WheelNeedle : MonoBehaviour {

    [SerializeField] string[] m_minigames;
    List<int> m_minigameIndexer = new List<int>();

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject.name);
        collider.gameObject.name = AssignGame();
    }

    private string AssignGame()
    {
        if (m_minigames.Length > 0)
        {
            if (m_minigameIndexer.Count == 0)
            {
                m_minigameIndexer.Clear();
                for (int i = 0; i < m_minigames.Length; i++)
                {
                    m_minigameIndexer.Add(i);
                }
            }
            int internalNr = Random.Range(0, m_minigameIndexer.Count);
            int externalNr = m_minigameIndexer[internalNr];
            m_minigameIndexer.Remove(externalNr);
            return m_minigames[externalNr];
        }
        else
        {
            Debug.Log("Minigames List in WheelNeedle is Empty");
            return "nothing";
        }
    }
}
