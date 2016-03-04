using UnityEngine;
using System.Collections;

public class AxisToButton : MonoBehaviour {

    private bool m_isAxisInUse = false;


    void Update ()
    {
        if (Input.GetAxisRaw("DPadY_P2") >= 0.5f)
        {
            if (m_isAxisInUse == false)
            {
                Debug.Log(Input.GetAxisRaw("DPadY_P2"));
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("DPadY_P2") == 0)
        {
            m_isAxisInUse = false;
        }
        if (Input.GetButtonDown("X_P2"))
        {
            Debug.Log(Input.GetAxisRaw("DPadY_P2"));
        }
    }
}
