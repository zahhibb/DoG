using UnityEngine;
using System.Collections;

public class InfluenceNeedle : MonoBehaviour
{
    [SerializeField] int m_myController = 1;
    private Manager m_myManager;
    [SerializeField] GameObject m_myIndicator = null;
    private float m_speed = 600;

    private void Start()
    {
        m_myManager = GameObject.FindGameObjectWithTag("ManagerP" + m_myController).GetComponent<Manager>();
    }

    private void Update()
    {
        if (Input.GetAxis(m_myManager.Inputs[12].name) != 0 || Input.GetAxis(m_myManager.Inputs[13].name) != 0 || Input.GetAxis(m_myManager.Inputs[14].name) != 0 || Input.GetAxis(m_myManager.Inputs[15].name) != 0)
        {
            GetRotations();
            float scaler = Mathf.Clamp(Mathf.Abs(Input.GetAxis(m_myManager.Inputs[12].name)) + Mathf.Abs(Input.GetAxis(m_myManager.Inputs[13].name)) + Mathf.Abs(Input.GetAxis(m_myManager.Inputs[14].name)) + Mathf.Abs(Input.GetAxis(m_myManager.Inputs[15].name)), 0, 1);
            m_myIndicator.transform.localScale = new Vector3(scaler, scaler, scaler);
        }
        else
        {
            m_myIndicator.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    private void GetRotations()
    {
        float x = Mathf.Clamp((Input.GetAxis(m_myManager.Inputs[12].name) + Input.GetAxis(m_myManager.Inputs[14].name)), -1f, 1f);
        float y = Mathf.Clamp((Input.GetAxis(m_myManager.Inputs[13].name) + Input.GetAxis(m_myManager.Inputs[15].name)), -1f, 1f);
        //float x = Input.GetAxis("LeftStickX_P1");
        //float y = Input.GetAxis("LeftStickY_P1");

        float angle = Mathf.Atan2(x, y) * 180 / Mathf.PI;

        Quaternion quaternionRotate = Quaternion.Euler(0f, angle + 180f, 0f);
        float step = m_speed * Time.deltaTime;
        m_myIndicator.gameObject.transform.localRotation = Quaternion.RotateTowards(m_myIndicator.gameObject.transform.localRotation, quaternionRotate, step);
    }
}
