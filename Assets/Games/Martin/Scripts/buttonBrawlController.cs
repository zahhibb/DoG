using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonBrawlController : MonoBehaviour {

	// The player managers, collected in awake. 
	private Manager m_MangerP1;
	private Manager m_MangerP2;
	private Manager m_MangerP3;
	private Manager m_MangerP4;
	private Manager[] m_Managers = new Manager[4];

	private string teamButton1 = "A_P2";
	private string teamButton2 = "B_P3";
	private string teamButton3 = "X_P4";
	private string teamButton4 = "Y_P1";


	// Variables for setting up the playfield
	[SerializeField] private GameObject m_playerWindow;
	[SerializeField] private GameObject m_Canvas;

	private int m_playerCount;

	// Use this for initialization
	void Awake () {
		m_MangerP1 = GameObject.FindGameObjectWithTag ("ManagerP1").GetComponent<Manager>();
		m_MangerP2 = GameObject.FindGameObjectWithTag ("ManagerP2").GetComponent<Manager>();
		m_MangerP3 = GameObject.FindGameObjectWithTag ("ManagerP3").GetComponent<Manager>();
		m_MangerP4 = GameObject.FindGameObjectWithTag ("ManagerP4").GetComponent<Manager>();

		if (m_MangerP1 != null) {
			m_Managers [0] = m_MangerP1;
		}

		if (m_MangerP2 != null) {
			m_Managers [1] = m_MangerP2;
		}

		if (m_MangerP3 != null) {
			m_Managers [2] = m_MangerP3;
		}

		if (m_MangerP4 != null) {
			m_Managers [3] = m_MangerP4;
		}
			
	}

	void Start(){
		

		if (m_Managers [3].Active) {
			m_playerCount = 4;
		} 
		else if (m_Managers [2].Active) {
			m_playerCount = 3;
		} 
		else if (m_Managers [1].Active) {
			m_playerCount = 2;
		} 
		else {
			m_playerCount = 1;
		}
		Debug.Log ( "number of players = " + m_playerCount.ToString());
		setupButtons ();
		initializeGame ();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (teamButton1)) {
			// Do win here
			m_MangerP1.Score += 4;
			m_MangerP2.Score += 1;
			m_MangerP3.Score += 1;
			m_MangerP4.Score += 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Celebration");
		}
		else if (Input.GetButtonDown (teamButton2) && m_playerCount == 2) {
			// Do win here
			m_MangerP1.Score += 1;
			m_MangerP2.Score += 4;
			m_MangerP3.Score += 1;
			m_MangerP4.Score += 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Celebration");

		}
		else if (Input.GetButtonDown (teamButton3) && m_playerCount == 3) {
			// Do win here
			m_MangerP1.Score += 1;
			m_MangerP2.Score += 1;
			m_MangerP3.Score += 4;
			m_MangerP4.Score += 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Celebration");
		}
		else if (Input.GetButtonDown (teamButton4) && m_playerCount == 4) {
			// Do win here
			m_MangerP1.Score += 1;
			m_MangerP2.Score += 1;
			m_MangerP3.Score += 1;
			m_MangerP4.Score += 4;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Celebration");
		}
		
	}

	void initializeGame(){
		
		switch (m_playerCount) {
		case 4:
			m_Canvas.GetComponent<GridLayoutGroup> ().cellSize = new Vector2 (1920 / 2, 1080 / 2);

			for (int i = 0; i < m_playerCount; i++) {
				GameObject playerWindow;
				playerWindow = Instantiate(m_playerWindow) as GameObject;
				playerWindow.transform.parent = m_Canvas.transform;
				playerWindow.transform.localScale = new Vector3 (1, 1, 1);
				playerWindow.GetComponent<playerPanel> ().setColor (m_Managers[i].PlayerColor);

				switch (i) {
				case 0:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				case 1:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton2);
					break;
				case 2:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton3);
					break;
				case 3:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton4);
					break;
				default:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				}
			}


			break;

		case 3:
			m_Canvas.GetComponent<GridLayoutGroup> ().cellSize = new Vector2(1920/2,1080/2);
			for (int i = 0; i < m_playerCount; i++) {
				GameObject playerWindow;
				playerWindow = Instantiate(m_playerWindow) as GameObject;
				playerWindow.transform.parent = m_Canvas.transform;
				playerWindow.transform.localScale = new Vector3 (1, 1, 1);
				playerWindow.GetComponent<playerPanel> ().setColor (m_Managers[i].PlayerColor);
				switch (i) {
				case 0:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				case 1:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton2);
					break;
				case 2:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton3);
					break;
				case 3:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton4);
					break;
				default:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				}
			}
			Debug.Log ( "number of players = " + m_playerCount.ToString());
			break;

		case 2:
			m_Canvas.GetComponent<GridLayoutGroup> ().cellSize = new Vector2(1920,1080/2);
			for (int i = 0; i < m_playerCount; i++) {
				GameObject playerWindow;
				playerWindow = Instantiate(m_playerWindow) as GameObject;
				playerWindow.transform.parent = m_Canvas.transform;
				playerWindow.transform.localScale = new Vector3 (1, 1, 1);
				playerWindow.GetComponent<playerPanel> ().setColor (m_Managers[i].PlayerColor);
				switch (i) {
				case 0:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				case 1:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton2);
					break;
				case 2:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton3);
					break;
				case 3:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton4);
					break;
				default:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				}
			}
			Debug.Log ( "number of players = " + m_playerCount.ToString());
			break;

		case 1:
			m_Canvas.GetComponent<GridLayoutGroup> ().cellSize = new Vector2(1920,1080);
			for (int i = 0; i < m_playerCount; i++) {
				GameObject playerWindow;
				playerWindow = Instantiate(m_playerWindow) as GameObject;
				playerWindow.transform.parent = m_Canvas.transform;
				playerWindow.transform.localScale = new Vector3 (1, 1, 1);
				playerWindow.GetComponent<playerPanel> ().setColor (m_Managers[i].PlayerColor);
				switch (i) {
				case 0:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				case 1:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton2);
					break;
				case 2:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton3);
					break;
				case 3:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton4);
					break;
				default:
					playerWindow.GetComponent<playerPanel> ().setButton (teamButton1);
					break;
				}
			}
			break;

		default:
			break;

		}	
	}

	void setupButtons(){
		if (m_playerCount == 4) {
			teamButton1 = selectButton (0);
			teamButton2 = selectButton (1);
			teamButton3 = selectButton (2);
			teamButton4 = selectButton (3);
		} 
		else if (m_playerCount == 3) {
			
			teamButton1 = selectButton (0);
			teamButton2 = selectButton (1);
			teamButton3 = selectButton (2);
		} 
		else if (m_playerCount == 2) {
			teamButton1 = selectButton (0);
			teamButton2 = selectButton (1);
		} 
		else {
			teamButton1 = selectButton (0);
		}
	}

	string selectButton(int managerNmb){
		string buttonStr;
		string teamStr;
		int teamNmb;
		int btnNmb;

		Random.seed = Random.Range (0, 150);
		teamNmb = Random.Range (0,m_playerCount);
		btnNmb = Random.Range (0,4);

		if (teamNmb != managerNmb) {
			
			switch (teamNmb) {
			case 3:
				teamStr = "4";
				break;
			case 2:
				teamStr = "3";
				break;
			case 1:
				teamStr = "2";
				break;
			case 0:
				teamStr = "1";
				break;
			default:
				teamStr = "1";
				break;
				
			}

		} else if ((teamNmb + 1) < m_playerCount) {
			Debug.Log ("+1 running");
			teamNmb += 1;
			switch (teamNmb) {
			case 3:
				teamStr = "4";
				break;
			case 2:
				teamStr = "3";
				break;
			case 1:
				teamStr = "2";
				break;
			case 0:
				teamStr = "1";
				break;
			default:
				teamStr = "1";
				break;

			}
		} else {
			Debug.Log ("-1 running");
			teamNmb -= 1;
			switch (teamNmb) {
			case 3:
				teamStr = "4";
				break;
			case 2:
				teamStr = "3";
				break;
			case 1:
				teamStr = "2";
				break;
			case 0:
				teamStr = "1";
				break;
			default:
				teamStr = "1";
				break;

			}
		}

		switch (btnNmb) {
		case 3:
			buttonStr = "A";
			break;
		case 2:
			buttonStr = "B";
			break;
		case 1:
			buttonStr = "X";
			break;
		case 0:
			buttonStr = "Y";
			break;
		default:
			buttonStr = "A";

			break;

		}
		Debug.Log ("return: " + buttonStr + "_" + "P" + teamStr);
		return (buttonStr + "_" + "P" + teamStr);
	}
}
