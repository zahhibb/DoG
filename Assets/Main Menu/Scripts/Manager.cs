using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField] private int m_teamSize = 1;
    private int m_teamNumber;
    private Button[] m_inputs;
    private int m_score = 0;
    [SerializeField] private bool m_active = false;
    [SerializeField] private Color m_playerColor;
    private Rect m_playerRect;
    private int m_rounds = 0;
    private string m_chosenScene;
    public int m_controllers = 0;

    private void Start()
    {
        //Debug.Log(gameObject.tag + " har " + m_teamSize + " spelare.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PrintInputs();
        }
    }

    public struct Button
    {
        public string name;
        public bool isAxis; //getters in structs? :|
    }

    public int TeamSize 
    {
        get { return m_teamSize; }
        set { m_teamSize = value; }
    }

    public int TeamNumber
    {
        get { return m_teamNumber; }
        set { m_teamNumber = value; }
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

    public string ChosenScene
    {
        get { return m_chosenScene; }
        set { m_chosenScene = value; }
    }

    // for debugging input issues
    private void PrintInputs()
    {
        for (int i = 0; i < 17; i++)
        {
            Debug.Log(gameObject.tag + " - input " + i + ": " + Inputs[i].name);
        }
    }

}
