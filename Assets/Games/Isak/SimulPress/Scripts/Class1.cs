using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SimulPress : MonoBehaviour
{
    [SerializeField] private int m_inputsPerPlayer = 4;

    private Dictionary<int, bool> m_inputDictionary;
    private List<int> m_inputIndices;
    private List<int> m_falseIndices;
    private List<string> m_inputNames;
    private List<Manager> m_playerManagers;

    private void Start()
    {

    }

    private void Update()
    {

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

    private void DetectInputs(List<int> falseIndices, List<int> inputIndices)
    {
        foreach (Manager team in m_playerManagers)
        {
            foreach (int inputIndex in inputIndices)
            {
                if (team.Inputs[inputIndex].isAxis)
                {
                    if (!Input.GetButtonDown(team.Inputs[inputIndex].name))
                    {
                        m_inputDictionary.Add(inputIndex, true);
                    }
                }
                else if (team.Inputs[inputIndex].isAxis)
                {       // this will add several hundred instances, the dictionary should be an array.
                    if (Input.GetAxis(team.Inputs[inputIndex].name) != 0) // needs cases for pos/neg.
                    {
                        m_inputDictionary.Add(inputIndex, true);
                    }
                }
                else
                {
                    Debug.Log("Attempted to access incorrect index from " + team.TeamName + "'s Input[] using index " + inputIndex + ".");
                }
                foreach (int falseIndex in falseIndices)
                {
                    if (team.Inputs[falseIndex].isAxis)
                    {
                        if (Input.GetAxis(team.Inputs[falseIndex].name) != 0) // this will add several hundred instances, the dictionary should be an array of bools.
                        {
                            m_inputDictionary.Add(falseIndex, false);
                        }
                    }
                    else if (!team.Inputs[falseIndex].isAxis)
                    {
                        if (Input.GetButtonDown(team.Inputs[falseIndex].name))
                        {
                            m_inputDictionary.Add(falseIndex, false);
                        }

                    }

                }
            }
        }
    }

    private List<int> MakeFalseIndices()
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < 17; i++)
        {
            tempList.Add(i);
        }
        return tempList;
    }

    // with Lists like these, who needs dicionaries?

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
    /* fix this one
    private void MakeActiveInputs(Manager myTeam)
    {
        int indexSkipper = 0;
        for (int i = 0; i < (4 + myTeam.TeamSize * 2); i++)
        {
            int indexAdder = Random.Range(0, 1);
            m_inputNames.Add(myTeam.Inputs[Random.Range(indexSkipper, (indexSkipper + indexAdder)) + i].name);
            indexSkipper = Mathf.Clamp(indexSkipper + indexAdder, 0, 5 - myTeam.TeamSize);

            // this won't work, but there is a way.
        }
    }
    */
}


