using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonA;
    [SerializeField]
    private GameObject buttonB;
    [SerializeField]
    private GameObject buttonX;
    [SerializeField]
    private GameObject buttonY;

    private int countdown;       //Time before button is instantiated
    private int buttonChoice;    //Which button to instantiate

    // Use this for initialization
    void Start ()
    {
        buttonChoice = Random.Range(1, 5);
        countdown = Random.Range(1, 10);
        StartCoroutine(ExecuteAfterTime(countdown));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //buttonChoice = Random.Range(1, 5);
        //countdown = Random.Range(1, 2);

        //if (buttonChoice == 1)
        //{
        //    Instantiate(buttonA);
        //}
        //else if (buttonChoice == 2)
        //{
        //    Instantiate(buttonB);
        //}
        //else if (buttonChoice == 3)
        //{
        //    Instantiate(buttonX);
        //}
        //else if (buttonChoice == 4)
        //{
        //    Instantiate(buttonY);
        //}
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(countdown);
        if(buttonChoice == 1)
        {
            Instantiate(buttonA);
        }
        else if (buttonChoice == 2)
        {
            Instantiate(buttonB);
        }
        else if (buttonChoice == 3)
        {
            Instantiate(buttonX);
        }
        else if (buttonChoice == 4)
        {
            Instantiate(buttonY);
        }
    }
}
