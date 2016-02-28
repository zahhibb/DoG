using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PrintStatement : MonoBehaviour
{
    // Input sprites
    [SerializeField] private List<Sprite> m_buttonSpriteList = new List<Sprite>();
    private List<Sprite> m_spriteListRef = new List<Sprite>();

    /* ATT GÖRA:
        - Skapa int referens lista till buttonSpriteList som tar bort motsvarande
          värde i denna nya lista för att undvika dDuUbBlLeEtTeErR.
        - Gör om buttonSpriteList till array, den skall inte ändras.
    */

    private SpriteRenderer[] m_randomButtons;
    private string[] m_questionStatement = new string[3] { "Water is wet", "Roses are pink", "Europe is a country" };    
    private string[] m_questionArr = new string[4] { "Water is wet", "Roses are pink", "Europe is a country", "What is your Favourite Colour?" };
    private int m_randQuestion;
    private int m_randInput;

    private int m_andQuestion;
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
        
    }    

    // Randomize button prompts
    private void RandomButtonPrompts()
    {
        GameObject[] sprites = GameObject.FindGameObjectsWithTag("Joystick1Input");
        m_randomButtons = new SpriteRenderer[sprites.Length];

        for (int i = 0; i < sprites.Length; ++i)
        {
            int randInput = Random.Range(0, m_buttonSpriteList.Count);
            m_randomButtons[i] = sprites[i].GetComponent<SpriteRenderer>();


            

            m_spriteListRef.Add(m_buttonSpriteList[randInput]);

            for (int matchCheck = 0; matchCheck < m_spriteListRef.Count; matchCheck++)
            {
                Debug.Log(m_spriteListRef[matchCheck]);
                if (m_buttonSpriteList[randInput] == m_spriteListRef[matchCheck])
                {
                    Debug.Log("Match!");
                    m_spriteListRef.RemoveAt(matchCheck);
                }
            }

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
