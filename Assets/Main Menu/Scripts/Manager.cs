using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField] private int m_teamSize;
    private Button[] m_inputs;
    private int m_score = 0;
    private bool m_active = false;
    private Color m_playerColor;
    private Rect m_playerRect;
    private int m_rounds = 0;
    public int m_controllers = 0;

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

    public int Rounds
        {
            get { return m_rounds; }
            set { m_rounds = value; }
        }

    public int Controllers
    {
        get { return m_controllers; }
        set { m_controllers = value; }
    }

    public bool Active
    {
        get { return m_active; }
        set { m_active = value; }
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
