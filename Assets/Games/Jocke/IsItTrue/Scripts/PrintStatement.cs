using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ButtonInputBind
{
    public string InputString;
    public Sprite InputSprite;
}

public class PrintStatement : MonoBehaviour
{
    public ButtonInputBind[] m_bindings;
    public ButtonInputBind m_playerOneTrue;
    public ButtonInputBind m_playerOneFalse;

    // Input sprites
    [SerializeField] private List<Sprite> m_buttonSpriteList = new List<Sprite>();
    private List<Sprite> m_spriteListRef = new List<Sprite>();

    private SpriteRenderer[] m_randomButtons;
    private string[] m_questionStatement = new string[3] { "Water is wet", "Roses are pink", "Europe is a country" };        
    private int m_randQuestion;
    
    private Text m_questionText;
    Question[] m_question = new Question[2];

    void Start()
    {       
        AddQuestion();
        RandomButtonPrompts();
        RandomQuestion();
    }

    void Update()
    {
        

        /*
        if (Input.GetButtonDown(m_playerOneTrue.InputString))
        {
            
        }*/        
    }

    // Randomize button prompts
    private void RandomButtonPrompts()
    {
        GameObject[] findGameobject = GameObject.FindGameObjectsWithTag("TrueButton");
        m_randomButtons = new SpriteRenderer[findGameobject.Length];

        for (int i = 0; i < findGameobject.Length; ++i)
        {
            int randInput = Random.Range(0, m_buttonSpriteList.Count);
            m_randomButtons[i] = findGameobject[i].GetComponent<SpriteRenderer>();
            m_randomButtons[i].sprite = m_buttonSpriteList[randInput];
        }
    }

    // Randomize and print question
    private void RandomQuestion()
    {        
        m_questionText = GameObject.FindGameObjectWithTag("QuestionStatement").GetComponent<Text>();
        m_randQuestion = Random.Range(0, m_questionStatement.Length);
        m_questionText.text = m_questionStatement[m_randQuestion];
    }    

    private void AddQuestion()
    {
        SetQuestion(0, "Ice is cold as Erik", true);
        SetQuestion(1, "Isak is cool as the Empire State building", false);
    }

    private struct Question
    {
        public string question;
        public bool answer;
    }

    private void SetQuestion(int index, string question, bool answer)
    {
        m_question[index].question = question;
        m_question[index].answer = answer;
    }
}
