using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SayMyName : MonoBehaviour
{
    [SerializeField] private Text m_text = null;

    void Update ()
    {
        m_text.text = gameObject.name;
	}
}
