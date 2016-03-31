using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerPanel : MonoBehaviour {

	[SerializeField] private GameObject m_panelBG;
	[SerializeField] private GameObject m_text;
	[SerializeField] private GameObject m_buttonIcon;

	[SerializeField] Sprite ASprite;
	[SerializeField] Sprite BSprite;
	[SerializeField] Sprite XSprite;
	[SerializeField] Sprite YSprite;

	private Color m_TeamColour;
	private bool isUpdated = true;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (!isUpdated) {

			isUpdated = true;
		}
	}

	public void setColor(Color colour){
		
		m_TeamColour = colour;
		m_panelBG.GetComponent<Image> ().color = m_TeamColour;
		isUpdated = false;
	}

	public void setButton(string button){
		m_text.GetComponent<Text> ().text = ("Press Team " + button.Substring (3,1)) + "'s";
		switch (button.Substring(0,1)) {
		case "A":
			m_buttonIcon.GetComponent<Image>().sprite = ASprite;
			break;
		case "B":
			m_buttonIcon.GetComponent<Image>().sprite = BSprite;
			break;
		case "X":
			m_buttonIcon.GetComponent<Image>().sprite = XSprite;
			break;
		case "Y":
			m_buttonIcon.GetComponent<Image>().sprite = YSprite;
			break;
		default:
			m_buttonIcon.GetComponent<Image>().sprite = BSprite;
			break;
		}
	}
}
