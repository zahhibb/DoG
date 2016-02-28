using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StagingText : MonoBehaviour {

    [SerializeField] Text m_text1 = null;
    [SerializeField] Text m_text2 = null;
    [SerializeField] Text m_text3 = null;
    [SerializeField] Text m_text4 = null;
    Manager m_playerManager = null;

    private void Start()
    {
        m_playerManager = GameObject.FindGameObjectWithTag("ManagerP" + gameObject.name).GetComponent<Manager>();
    }

    void Update()
    {
        m_text1.text = "Controller: " + m_playerManager.gameObject.name;
        m_text2.text = "Players on team: " + m_playerManager.TeamSize;
        m_text3.text = "Team score: " + m_playerManager.Score;
        m_text4.text = "Inputs[3]: (0-16)" + m_playerManager.Inputs[3].name;
    }
}
