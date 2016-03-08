using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderText : MonoBehaviour {

    private Slider m_slider = null;
    [SerializeField] private Text m_text = null;
    private Manager m_targetPlayer = null;
    private bool m_isXAxisInUse = false;

    private void Start()
    {
        m_targetPlayer = GameObject.FindGameObjectWithTag("ManagerP" + m_text.gameObject.name).GetComponent<Manager>();
        m_slider = gameObject.GetComponent<Slider>();
        m_text = gameObject.GetComponentInChildren<Text>();
        m_text.text = "Players on team: " + m_targetPlayer.TeamSize;
    }
	
    void Update()
    {
        if (Input.GetAxisRaw(m_targetPlayer.Inputs[10].name) >= 0.5f)
        {
            if (m_isXAxisInUse == false)
            {
                m_slider.value++;
                OnSliderUpdate();
                m_isXAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw(m_targetPlayer.Inputs[10].name) <= -0.5f)
        {
            if (m_isXAxisInUse == false)
            {
                m_slider.value--;
                OnSliderUpdate();
                m_isXAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw(m_targetPlayer.Inputs[10].name) == 0)
        {
            m_isXAxisInUse = false;
        }
    }

    public void OnSliderUpdate()
    {
        // This one is really dirty, should make a more solid solution. (don't forget to name the sliders)
        if (GameObject.FindGameObjectWithTag("ManagerP" + m_text.gameObject.name) != null)
        {
            m_targetPlayer = GameObject.FindGameObjectWithTag("ManagerP" + m_text.gameObject.name).GetComponent<Manager>();
            m_text.text = "Players on team: " + m_slider.value;
            m_targetPlayer.TeamSize = (int)m_slider.value;
            Debug.Log(m_targetPlayer.tag + ": " + m_targetPlayer.TeamSize);
        }
    }

}
