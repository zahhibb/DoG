using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject m_teamCanvas;
    private Camera m_teamCamera;


    void Start () {
        
    }
	
	
	void Update () {
	
	}


    private void MakeTeam()
    {
        Manager managerP1 = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>();
        

        managerP1.controllers; // Får kolla med isaks nya version
        for (int i = 0; i < managerP1.controllers; i++)
        {
            
            GameObject teamCanvas = (GameObject)Instantiate(m_teamCanvas, new Vector3(0, 0, 0), transform.rotation);
            TeamButton teamButtonScr = teamCanvas.GetComponentInChildren<TeamButton>();
            teamButtonScr.MyManager = GameObject.FindGameObjectWithTag("ManagerP" + (i+1)).GetComponent<Manager>();

        }
        
    }


}
