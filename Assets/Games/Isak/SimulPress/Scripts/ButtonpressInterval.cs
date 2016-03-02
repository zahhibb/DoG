using UnityEngine;
using System.Collections;
using UnityEditor;

public class ButtonpressInterval : MonoBehaviour {

    // try to make this instantiable per controller (input is the crux)

    private float m_startTimeP1 = 0f;
    /*
    private float m_startTimeP2 = 0f;
    private float m_startTimeP3 = 0f;
    private float m_startTimeP4 = 0f;
    */
    private float m_endTimeP1 = 0f;
    /*
    private float m_endTimeP2 = 0f;
    private float m_endTimeP3 = 0f;
    private float m_endTimeP4 = 0f;
    */
    private SerializedProperty[] m_inputArray;
    private string[] m_buttonNames;
    private Button[] m_pressedP1;

    void Start ()
    {
        FetchAxis();
        /*
        *if (playerPerTeamAmount < x)
        *{
        *   PossibleButtonAmount = (x == 1) ? y : z;
        *}
        */

        // Turn over cards to reveal "what you pressed" (sounds retarded but is probably fun)
    }

    private void Update()
    {
        //CheckButton(m_pressedP1);

    }

    private void FetchAxis()
    {
        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

        SerializedObject obj = new SerializedObject(inputManager);

        SerializedProperty m_inputArray = obj.FindProperty("m_Axes");

        if (m_inputArray.arraySize == 0)
        {
            Debug.Log("No Axes");
        }
        else
        {
            m_pressedP1 = new Button[m_inputArray.arraySize];
            for (int i = 0; i < m_inputArray.arraySize; ++i)            // here make array size a total of controllers present * inputs per controller
            {
                var axis = m_inputArray.GetArrayElementAtIndex(i);

                var name = axis.FindPropertyRelative("m_Name").stringValue;
                //maybe find the "description" path to check for controller number?
                var axisVal = axis.FindPropertyRelative("axis").intValue;
                var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

                Debug.Log(name);
                Debug.Log(axisVal);
                Debug.Log(inputType);

                m_pressedP1[i].pressed = false;
                m_pressedP1[i].name = axis.FindPropertyRelative("m_Name").stringValue;
            }
        }
    }

    private struct Button
    {
        public string name;
        public bool pressed; //getters in structs? :|
    };

    private enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };

    private void CheckButton(Button[] buttons)
    {
        bool isThatAll = false;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].pressed == false && m_startTimeP1 == 0)
            {
                buttons[i].pressed = (Input.GetKeyDown(buttons[i].name));
                // send to funky bar filling up and/or cards flipping over
                m_startTimeP1 = Time.realtimeSinceStartup;
                if (!isThatAll)
                {
                    isThatAll = true;
                }
            }
        }        
    }

    public void BackToStaging(int player)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Staging");
    }
}

