using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

public class MainMenuManager : Manager {

    [SerializeField] private Camera m_controller1Cam = null;
    [SerializeField] private Camera m_controller2Cam = null;
    [SerializeField] private Camera m_controller3Cam = null;
    [SerializeField] private Camera m_controller4Cam = null;

    private Manager m_ManagerP1 = null;
    private Manager m_ManagerP2 = null;
    private Manager m_ManagerP3 = null;
    private Manager m_ManagerP4 = null;

    [SerializeField] private Slider m_slider1 = null;
    [SerializeField] private Slider m_slider2 = null;
    [SerializeField] private Slider m_slider3 = null;
    [SerializeField] private Slider m_slider4 = null;

    [SerializeField] private int m_joysticks;
    [SerializeField] private GameObject m_playerManager = null;

    private SerializedProperty[] m_inputManagerArray;
    private Button[] m_buttonArray;
    //private string[] m_controller = Input.GetJoystickNames();

    // Standard Colors (there needs to be as many as of these as there are supported controllers!)
    private Color m_lemonTruck = new Color(249, 227, 105);
    private Color m_beachBlueCoathanger = new Color(148, 233, 246);
    private Color m_flamingoParachute = new Color(234, 160, 223);
    private Color m_greenPepperGranola = new Color(140, 253, 125);

    // Standard Viewport Rectangles
    private Rect m_fullscreen = new Rect(0f, 0f, 1f, 1f);
    private Rect m_topLeft = new Rect(0f, 0.5f, 0.5f, 1f);
    private Rect m_topRight = new Rect(0.5f, 0.5f, 0.5f, 1f);
    private Rect m_bottomLeft = new Rect(0f, 0f, 0.5f, 0.5f);
    private Rect m_bottomRight = new Rect(0.5f, -0.5f, 1f, 1f);
    private Rect m_topHalf = new Rect(0f, 0.5f, 1f, 1f);
    private Rect m_bottomHalf = new Rect(0f, 0f, 1f, 0.5f);
    private List<Color> m_colorList = new List<Color>();


    void Start()
    {
        MakeInputsFromIM();
        MakeColors();
        MakeTeams();

        SetCameras();

    }

    void Update()
    {
        TestCameras();
        m_ManagerP1.TeamSize = SliderSelect(m_slider1);
        m_ManagerP2.TeamSize = SliderSelect(m_slider2);
        m_ManagerP3.TeamSize = SliderSelect(m_slider3);
        m_ManagerP4.TeamSize = SliderSelect(m_slider4);

    }

    void MakePlayers()
    {
        m_joysticks = Input.GetJoystickNames().Length + 1;
        
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

    private void MakeManager(int controller, int teamSize)
    {

        // Initialize a new instance of Manager to the parametered team number and player count.
        GameObject newPlayerManager = (GameObject) Instantiate(m_playerManager, transform.position, transform.rotation);
        Persistency persistencyScript = newPlayerManager.gameObject.AddComponent<Persistency>();
        newPlayerManager.name = "Player " + controller + " Manager";
        Manager newManager = newPlayerManager.gameObject.AddComponent<Manager>();
        newManager.gameObject.tag = "ManagerP" + controller;
        newManager.TeamSize = teamSize;

        // Set up Inputs array, really only supports xBox controllers. :(
        newManager.Inputs = new Button[17];
        for (int i = 0; i < 17; i++)
        {
            newManager.Inputs[i] = m_buttonArray[i + (17 * (controller - 1))];
            //Debug.Log(newManager.Inputs[i].name);
        }

        // Give it a pretty color!
        //newManager.PlayerColor = SetColor();

        // Set up whatever variables it will need.
        newManager.Score = 0;
        newManager.enabled = true; //??
    }

    private int SliderSelect(Slider slider)
    {
        int players = 1;
        //Debug.Log(GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().TeamSize);
        players = (int)slider.value;

        return players;
    }

    private void MakeTeams()
    {

        MakeManager(1, 1);
        MakeManager(2, 1);
        MakeManager(3, 1);
        MakeManager(4, 1);

        m_ManagerP1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_ManagerP2 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_ManagerP3 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        m_ManagerP4 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();

    }

    private void SetCameras()
    {
        if (m_joysticks == 4)
        {
            m_controller1Cam.rect = m_topLeft;
            GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().PlayerRect = m_topLeft;
            m_controller1Cam.enabled = true;
            m_controller2Cam.rect = m_topRight;
            GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().PlayerRect = m_topRight;
            m_controller2Cam.enabled = true;
            m_controller3Cam.rect = m_bottomLeft;
            GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().PlayerRect = m_bottomLeft;
            m_controller3Cam.enabled = true;
            m_controller4Cam.rect = m_bottomRight;
            GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().PlayerRect = m_bottomRight;
            m_controller4Cam.enabled = true;
        }
        else if (m_joysticks == 3)
        {
            m_controller1Cam.rect = m_topHalf;
            GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().PlayerRect = m_topHalf;
            m_controller2Cam.enabled = true;
            m_controller2Cam.rect = m_bottomLeft;
            GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().PlayerRect = m_bottomLeft;
            m_controller2Cam.enabled = true;
            m_controller3Cam.rect = m_bottomRight;
            GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().PlayerRect = m_bottomRight;
            m_controller3Cam.enabled = true;
            m_controller4Cam.enabled = false;
        }
        else if (m_joysticks == 2)
        {
            m_controller1Cam.rect = m_topHalf;
            GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().PlayerRect = m_topHalf;
            m_controller1Cam.enabled = true;
            m_controller2Cam.rect = m_bottomHalf;
            GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().PlayerRect = m_bottomHalf;
            m_controller2Cam.enabled = true;
            m_controller3Cam.enabled = false;
            m_controller4Cam.enabled = false;
        }
        else if (m_joysticks == 1)
        {
            m_controller1Cam.rect = m_fullscreen;
            GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().PlayerRect = m_fullscreen;
            m_controller1Cam.enabled = true;
            m_controller2Cam.enabled = false;
            m_controller3Cam.enabled = false;
            m_controller4Cam.enabled = false;
        }

        /*
        m_controller1Cam.backgroundColor = m_flamingoParachute;
        GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().PlayerColor = m_controller1Cam.backgroundColor;
        m_controller2Cam.backgroundColor = SetColor();
        GameObject.FindGameObjectWithTag("ManagerP2").GetComponent<Manager>().PlayerColor = m_controller2Cam.backgroundColor;
        m_controller3Cam.backgroundColor = SetColor();
        GameObject.FindGameObjectWithTag("ManagerP3").GetComponent<Manager>().PlayerColor = m_controller3Cam.backgroundColor;
        m_controller4Cam.backgroundColor = SetColor();
        GameObject.FindGameObjectWithTag("ManagerP4").GetComponent<Manager>().PlayerColor = m_controller4Cam.backgroundColor;
        */
    }

    private void TestCameras()
    {
        MakeColors();

        if ((Input.GetKeyDown("f4")))
        {
            GameObject p4 = GameObject.FindGameObjectWithTag("ManagerP4");
            Manager managerp4 = p4.GetComponent<Manager>();

            m_controller1Cam.rect = m_topLeft;
            m_controller1Cam.enabled = true;
            m_controller2Cam.rect = m_topRight;
            m_controller2Cam.enabled = true;
            m_controller3Cam.rect = m_bottomLeft;
            m_controller3Cam.enabled = true;
            m_controller4Cam.rect = m_bottomRight;
            m_controller4Cam.enabled = true;
        }
        else if ((Input.GetKeyDown("f3")))
        {
            m_controller1Cam.rect = new Rect(0f, 0.5f, 1f, 1f);
            m_controller2Cam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
            m_controller2Cam.enabled = true;
            m_controller3Cam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
            m_controller3Cam.enabled = true;
            m_controller4Cam.enabled = false;
        }
        else if ((Input.GetKeyDown("f2")))
        {
            m_controller1Cam.rect = new Rect(0f, 0.5f, 1f, 1f);
            m_controller1Cam.enabled = true;
            m_controller2Cam.rect = new Rect(0f, 0f, 1f, 0.5f);
            m_controller2Cam.enabled = true;
            m_controller3Cam.enabled = false;
            m_controller4Cam.enabled = false;
        }
        else if ((Input.GetKeyDown("f1")))
        {
            m_controller1Cam.rect = new Rect(0f, 0f, 1f, 1f);
            m_controller1Cam.enabled = true;
            m_controller2Cam.enabled = false;
            m_controller3Cam.enabled = false;
            m_controller4Cam.enabled = false;
        }
    }

    void MakeColors()
    {
        //List<Color> colorLm_colorListist = new List<Color>();

        m_colorList.AddRange(new Color[] { m_lemonTruck, m_beachBlueCoathanger, m_flamingoParachute, m_greenPepperGranola });

        m_colorList.Add(m_lemonTruck);
        m_colorList.Add(m_beachBlueCoathanger);
        m_colorList.Add(m_flamingoParachute);
        m_colorList.Add(m_greenPepperGranola);
    }

    private Color SetColor()
    {
        Color color = Color.cyan;
        if (m_colorList.Count >= 1)
        {
            int index = Random.Range(0, (m_colorList.Count));
            color = m_colorList[index];
            m_colorList.Remove(m_colorList[index]);
        }
        return color;
    }
}
