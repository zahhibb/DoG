using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SayMyName : MonoBehaviour
{
    [SerializeField] private Text m_text = null;
    private string m_myName = "nothing...";
    public string MyName { get { return m_myName; } }

    void Update ()
    {
        switch (gameObject.name)
        {
            case ("Floppy1"):
                m_myName = "Floppy Man";
                break;
            case ("Aliens"):
                m_myName = "Shooting Turrets";
                break;
            case ("tanks_test"):
                m_myName = "Panzer TankMadels";
                break;
            default:
                m_myName = gameObject.name;
                break;
        }
        m_text.text = m_myName;
        //m_text.text = gameObject.name;
	}
}
