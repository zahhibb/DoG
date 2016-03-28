using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SimulPress : MonoBehaviour
{
    [SerializeField] private int m_inputsPerPlayer = 5;
    public int InputsPerPlayer { set { m_inputsPerPlayer = value; } }

    private bool m_clockRunning = false;
    public bool ClockIsRunning {  get { return m_clockRunning; } }
    private float m_timeSinceFirstPress = 0f;
    public float TimeSinceFirstPress { get { return m_timeSinceFirstPress; } }

    [SerializeField] private GameObject[] m_trueImages;
    [SerializeField] private GameObject[] m_falseImages;
    [SerializeField] private Text m_timerText;
    //private List<GameObject> m_activeImages;

    //private Dictionary<int, bool> m_inputDictionary;
    private List<int> m_trueIndices;
    public List<int> TrueIndices { get { return m_trueIndices; } }
    private List<int> m_falseIndices;
    private Manager m_teamManager;
    public Manager TeamManager {  set { m_teamManager = value; } get { return m_teamManager; } }
    private int[] m_inputStates;
    public int[] InputStatesArray { get { return m_inputStates; } }

    private bool m_gameRunning = false;
    private int m_stateIndexer;
    private int m_maxErrors = 2;

    private void Start()
    {

    }

    private void Update()
    {
        // end/start should be properly animated for the user before setting to m_gameRunning.
        if (!m_gameRunning)
        {
            int xBoxInputs = 4;

            m_falseIndices = MakeFalseIndices(xBoxInputs); // gör detta centralt istället eller?
            m_trueIndices = MakeTrueIndices(m_falseIndices, m_teamManager);

            m_stateIndexer = 0;
            m_inputStates = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            m_gameRunning = true;
        }

        if ((CheckForTrue(m_inputStates) > 0) || ( CheckForFalse(m_inputStates) > 0))
        {
            m_clockRunning = true;
        }
        if ((CheckForTrue(m_inputStates) < (m_inputsPerPlayer * m_teamManager.TeamSize) && (CheckForFalse(m_inputStates) <= (m_maxErrors * m_teamManager.TeamSize))))
        {
            InputStates(m_teamManager);
        }
        else
        {
            // do check.
        }

        if (m_clockRunning)
        {
            m_timeSinceFirstPress += Time.deltaTime;
            m_timerText.text = string.Format("{00.00}", TimeSinceFirstPress); // does this even work?
        }
    }

    //private void MakeInputCollectors()
    //{
    //    int teamAmount = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().Controllers;
    //    for (int i = 0; i < teamAmount; i++)
    //    {
    //        GameObject collector = Instantiate(new GameObject, transform.position, transform.rotation);
    //        collector.name = "Collector " + (i + 1);
    //        InputCollector myCollector = collector.AddComponent<InputCollector>();
    //        myCollector.FalseIndices = MakeFalseIndices();
    //        myCollector.TrueIndices = MakeTrueIndices(myCollector.FalseIndices)
    //    }
    //}

    private void InputStates(Manager myManager)
    {

        // 0 - untouched.
        // 1 - true.
        // 2 - false.

        foreach (int tKey in m_trueIndices)
        {
            if (myManager.Inputs[tKey].isAxis)
            {
                if (Input.GetAxis(myManager.Inputs[tKey].name) != 0f) // not deadzone safe :(
                {                 
                    m_stateIndexer++;
                    m_inputStates[tKey] = 1;
                }
            }
            else if (!myManager.Inputs[tKey].isAxis)
            {
                if (Input.GetButton(myManager.Inputs[tKey].name))
                {
                    m_stateIndexer++;
                    m_inputStates[tKey] = 1;
                }
            }
        }

        foreach (int fKey in m_falseIndices)
        {
            if (myManager.Inputs[fKey].isAxis)
            {
                if (Input.GetAxis(myManager.Inputs[fKey].name) != 0f)
                {
                    m_stateIndexer++;
                    m_inputStates[fKey] = 2;
                }
            }
            else if (!myManager.Inputs[fKey].isAxis)
            {
                if (Input.GetButton(myManager.Inputs[fKey].name))
                {
                    m_stateIndexer++;
                    m_inputStates[fKey] = 2;
                }
            }
        }
    }

    private bool AllInputsUsed(int[] inputStates)
    {
        // returns false if any one index in States is "untouched".

        bool anyInput = true;
        foreach (int state in m_inputStates)
        {
            if (state == 0)
            {
                anyInput = false;
            }
        }
        return anyInput;
    }

    // with Lists like these, who needs dicionaries? 

    private List<int> MakeFalseIndices(int amount)
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < amount; i++)
        {
            tempList.Add(i);
        }
        return tempList;
    }

    private List<int> MakeTrueIndices(List<int> falseIndices, Manager team)
    {
        List<int> tempList = new List<int>();

        for (int i = 0; i < (m_inputsPerPlayer /* * team.TeamSize */ ); i++)
        {
            int index = Random.Range(0, falseIndices.Count);
            falseIndices.Remove(index);
            tempList.Add(index);
        }

        return tempList;
    }

    private int CheckForTrue(int[] qStateArray)
    {
        int count = 0;
        foreach (int key in qStateArray)
        {
            if (key == 2)
            {
                count++;
            }
        }
        return count;
    }

    private int CheckForFalse(int[] qStateArray)
    {
        int count = 0;
        foreach (int key in qStateArray)
        {
            if (key == 1)
            {
                count++;
            }
        }
        return count;
    }

    //private void AddImage(GameObject image)
    //{
    //    image.SetActive(true);
    //    m_activeImages.Add(image);
    //}

    //private void DisplayImages()
    //{

    //}

    //private void ClearImages()
    //{
    //    foreach (GameObject image in m_activeImages)
    //    {
    //        image.transform.position = new Vector3(0, 0, 0);
    //        image.SetActive(false);
    //    }
    //    m_activeImages.Clear();
    //}

}