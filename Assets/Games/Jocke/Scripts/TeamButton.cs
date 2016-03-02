using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TeamButton : MonoBehaviour {

    [SerializeField] private List<Sprite> m_buttonSpriteList = new List<Sprite>();
    private List<int> m_randIndex;

    [SerializeField] Button m_trueButton;
    [SerializeField] Button m_falseButton;

    InputButton[] m_inputButton = new InputButton[6];

    private Manager m_myManager = null;

    private string m_trueInput;
    private string m_falseInput;

    private int m_myTeam;

    public Manager MyManager
    {
        set { m_myManager = value; }
    }

    void Start ()
    {
        gameObject.GetComponentInChildren<Camera>().rect = m_myManager.PlayerRect;

        InputList();
        NewIndex();

        m_trueInput = SetButton(m_trueButton);
        m_falseInput = SetButton(m_falseButton);
    }
	
	
	void Update ()
    {
        if (Input.GetButtonDown(m_trueInput))
        {
            
        }
        else if (Input.GetButtonDown(m_falseInput))
        {

        }
	}

    private void InputList()
    {
        m_inputButton[0].spr = m_buttonSpriteList[0];
        m_inputButton[1].spr = m_buttonSpriteList[1];
        m_inputButton[2].spr = m_buttonSpriteList[2];
        m_inputButton[3].spr = m_buttonSpriteList[3];
        m_inputButton[4].spr = m_buttonSpriteList[4];
        m_inputButton[5].spr = m_buttonSpriteList[5];

        m_inputButton[0].input = m_myManager.Inputs[0].name;
        m_inputButton[1].input = m_myManager.Inputs[1].name;
        m_inputButton[2].input = m_myManager.Inputs[2].name;
        m_inputButton[3].input = m_myManager.Inputs[3].name;
        m_inputButton[4].input = m_myManager.Inputs[4].name;
        m_inputButton[5].input = m_myManager.Inputs[5].name;
    }

    private void NewIndex()
    {
        m_randIndex.Clear();
        for (int i = 0; i < m_inputButton.Length; i++ )
        {
            m_randIndex.Add(i);
        }
    }

    private string SetButton(Button btn)
    {
        int index = Random.Range(0, m_randIndex.Count);
        m_randIndex.RemoveAt(index);

        btn.image.sprite = m_inputButton[index].spr;

        return m_inputButton[index].input;
    }

    private struct InputButton
    {
        public string input;
        public Sprite spr;
    }
}
