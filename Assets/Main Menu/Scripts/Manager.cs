using UnityEngine;
using System.Collections;
using UnityEditor;

public class Manager : MonoBehaviour
{
    [SerializeField] private int m_teamSize;
    private Button[] m_inputs;
    private int m_score = 0;
    private bool m_active = false;
    private Color m_playerColor;
    private Rect m_playerRect;

    private void Start()
    {
        //Debug.Log(gameObject.tag + " har " + m_teamSize + " spelare.");
    }

    public struct Button
    {
        public string name;
        public bool pressed; //getters in structs? :|
    }

    public int TeamSize 
    {
        get { return m_teamSize; }
        set { m_teamSize = value; }
    }

    public int Score
    {
        get { return m_score; }
        set { m_score = value; }
    }

    public Button[] Inputs
    {
        get { return m_inputs; }
        set { m_inputs = value; }
    }

    public Color PlayerColor
    {
        get { return m_playerColor; }
        set { m_playerColor = value; }
    }

    public Rect PlayerRect
    {
        get { return m_playerRect; }
        set { m_playerRect = value; }
    }
}
