using UnityEngine;
using System.Collections;
using UnityEditor;

public class InputAccess : Manager {

    private SerializedProperty[] m_inputManagerArray;
    Button[] m_buttonArray;

    private void Awake()
    {
        MakeInputsFromIM();
        SetManagerInputArray();
    }

    private void MakeInputsFromIM()
    {
        // this function makes m_buttonArray contain all inputs from input manager.

        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];
        SerializedObject obj = new SerializedObject(inputManager);
        SerializedProperty m_inputArray = obj.FindProperty("m_Axes");


        m_buttonArray = new Button[m_inputArray.arraySize];

        for (int i = 0; i < m_inputArray.arraySize; ++i)
        {
            var axis = m_inputArray.GetArrayElementAtIndex(i);
            var name = axis.FindPropertyRelative("m_Name").stringValue;
            var axisVal = axis.FindPropertyRelative("axis").intValue;

            //Debug.Log(name);
            //Debug.Log(axisVal);

            m_buttonArray[i].pressed = false;
            m_buttonArray[i].name = axis.FindPropertyRelative("m_Name").stringValue;

        }
    }

    private void SetManagerInputArray()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuManager>().InputManagerArray = m_buttonArray;
    }

    public Button[] InputManagerArray
    {
        get { return m_buttonArray; }
    }
}
