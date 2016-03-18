using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheelSelector : MonoBehaviour
{
    [SerializeField] Text m_currentText = null;

    private string m_sceneUnderNeedle;
    public string SceneUnderNeedle { get { return m_sceneUnderNeedle; } }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject.name);
        m_currentText.text = collider.gameObject.name;
        m_sceneUnderNeedle = collider.gameObject.name;
    }

}
