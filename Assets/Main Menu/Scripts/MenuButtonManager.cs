using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuButtonManager : MonoBehaviour {

    [SerializeField] private Canvas m_canvas1 = null;
    [SerializeField] private Slider m_pSlider = null;

    [SerializeField] private Button m_a = null;
    [SerializeField] private Button m_x = null;
    [SerializeField] private Button m_b = null;


    void Start ()
    {
	    
	}
	

	void Update ()
    {
        if (Input.GetButtonDown("A_P1"))
        {
            m_a.Select();
        }
        if (Input.GetButtonDown("X_P1"))
        {
            m_x.Select();
        }
        if (Input.GetButtonDown("B_P1"))
        {
            m_b.Select();
        }
        if (Input.GetButtonDown("Back_P1"))
        {
            m_pSlider.value = Mathf.Clamp(m_pSlider.value-1, 1, 4);
        }
        if (Input.GetButtonDown("Start_P1"))
        {
            m_pSlider.value = Mathf.Clamp(m_pSlider.value+1, 1, 4);
        }
    }
}
