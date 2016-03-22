using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SimulPress : MonoBehaviour
{
    [SerializeField] private int m_inputsPerPlayer = 4;

    private Dictionary<int, bool> m_inputDictionary;
    private List<int> m_trueIndices;
    private List<int> m_falseIndices;
    private List<string> m_inputNames;
    private List<Manager> m_playerManagers;

    private int[] m_inputStates;
    private bool m_gameRunning = false;
    private int m_stateIndexer;

    private void Start()
    {

    }

    private void Update()
    {
        if (!m_gameRunning)
        {
            m_stateIndexer = 0;
            m_inputStates = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            m_gameRunning = true;
        }
        //InputStates(m_myManager);
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

        foreach (int key in m_trueIndices)
        {
            if (myManager.Inputs[key].isAxis)
            {
                if (Input.GetAxis(myManager.Inputs[key].name) != 0f)
                {
                    m_inputStates[key] = 1;
                }
            }
            else if (!myManager.Inputs[key].isAxis)
            {
                if (Input.GetButton(myManager.Inputs[key].name))
                {
                    m_inputStates[key] = 1;
                }
            }
        }

        foreach (int key in m_falseIndices)
        {
            if (myManager.Inputs[key].isAxis)
            {
                if (Input.GetAxis(myManager.Inputs[key].name) != 0f)
                {
                    m_inputStates[key] = 2;
                }
            }
            else if (!myManager.Inputs[key].isAxis)
            {
                if (Input.GetButton(myManager.Inputs[key].name))
                {
                    m_inputStates[key] = 2;
                }
            }
        }
    }

    private bool AllInputsUsed(int[] inputStates)
    {
        bool anyInput = false;
        foreach ( int state in m_inputStates)
        {
            if (state != 0)
            {
                anyInput = true;
            }
        }
        return anyInput;
    }

    //private void DetectInputs(List<int> falseIndices, List<int> inputIndices)
    //{
    //    foreach (Manager team in m_playerManagers)
    //    {
    //        foreach (int inputIndex in inputIndices)
    //        {
    //            if (!team.Inputs[inputIndex].isAxis)
    //            {
    //                if (!Input.GetButtonDown(team.Inputs[inputIndex].name))
    //                {
    //                    m_inputDictionary.Add(inputIndex, true);
    //                }
    //            }
    //            else if (team.Inputs[inputIndex].isAxis)
    //            {       // this will add several hundred instances, the dictionary should be an array.
    //                if (Input.GetAxis(team.Inputs[inputIndex].name) != 0) // needs cases for pos/neg.
    //                {
    //                    m_inputDictionary.Add(inputIndex, true);
    //                }
    //            }
    //            else
    //            {
    //                Debug.Log("Attempted to access incorrect index from " + team.TeamName + "'s Input[] using index " + inputIndex + ".");
    //            }
    //            foreach (int falseIndex in falseIndices)
    //            {
    //                if (team.Inputs[falseIndex].isAxis)
    //                {
    //                    if (Input.GetAxis(team.Inputs[falseIndex].name) != 0) // this will add several hundred instances, the dictionary should be an array of bools.
    //                    {
    //                        m_inputDictionary.Add(falseIndex, false);
    //                    }
    //                }
    //                else if (!team.Inputs[falseIndex].isAxis)
    //                {
    //                    if (Input.GetButtonDown(team.Inputs[falseIndex].name))
    //                    {
    //                        m_inputDictionary.Add(falseIndex, false);
    //                    }

    //                }

    //            }
    //        }
    //    }
    //}

    private List<int> MakeFalseIndices()
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < 17; i++)
        {
            tempList.Add(i);
        }
        return tempList;
    }

    private List<int> MakeTrueIndices(List<int> falseIndices, Manager team)
    {
        List<int> tempList = new List<int>();

        for (int i = 0; i < ( m_inputsPerPlayer * team.TeamSize ); i++)
        {
            int index = Random.Range(0, falseIndices.Count);
            falseIndices.Remove(index);
            tempList.Add(index);
        }

        return tempList;
    }

    // with Lists like these, who needs dicionaries?  
}


