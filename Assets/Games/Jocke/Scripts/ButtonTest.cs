using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour {

    [SerializeField] private List<Sprite> m_buttonSpriteList = new List<Sprite>();

    SpriteRenderer m_curSprite;

    private int m_randTrue;
    private int m_randFalse;

    void Start ()
    {
        TrueButton();
        FalseButton();

        /*
         GameObject text = new GameObject();
         text.gameObject.AddComponent<Text>();
        */
    }

    void Update()
    {
        
    }

    private void TrueButton()
    {
        m_randTrue = Random.Range(0, m_buttonSpriteList.Count);
        m_curSprite = gameObject.GetComponent<SpriteRenderer>();
        
        switch (m_randTrue)
        {
            case 0:
                m_curSprite.sprite = m_buttonSpriteList[0];                
                break;
            case 1:                
                m_curSprite.sprite = m_buttonSpriteList[1];                
                break;
            case 2:
                m_curSprite.sprite = m_buttonSpriteList[2];                
                break;
            case 3:                
                m_curSprite.sprite = m_buttonSpriteList[3];                
                break;
            case 4:                
                m_curSprite.sprite = m_buttonSpriteList[4];                
                break;
            case 5:                
                m_curSprite.sprite = m_buttonSpriteList[5];                
                break;
        }

        
    }

    private void FalseButton()
    {
        m_randFalse = Random.Range(0, m_buttonSpriteList.Count);

        while (m_randFalse == m_randTrue)
        {
            m_randFalse = Random.Range(0, m_buttonSpriteList.Count);
        }
            switch (m_randFalse)
            {
                case 0:
                    m_curSprite.sprite = m_buttonSpriteList[0];
                    break;
                case 1:
                    m_curSprite.sprite = m_buttonSpriteList[1];
                    break;
                case 2:
                    m_curSprite.sprite = m_buttonSpriteList[2];
                    break;
                case 3:
                    m_curSprite.sprite = m_buttonSpriteList[3];
                    break;
                case 4:
                    m_curSprite.sprite = m_buttonSpriteList[4];
                    break;
                case 5:
                    m_curSprite.sprite = m_buttonSpriteList[5];
                    break;
            }        
    }

    /*
    private struct Answer
    {
        public int spriteRef;
        public string input;
    }
    */
}
