using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CelebrationScaler : MonoBehaviour {

    [SerializeField] private GameObject[] m_bars;

    private float[] m_scaleArray;
    public float[] ScaleArray { set { m_scaleArray = value; } }

    //private void Start ()
    //{
    //    foreach (GameObject bar in m_bars)
    //    {
    //        bar.transform.localScale = new Vector3(1f, 1f, 1f);
    //    }
    //}

    private void Update()
    {
        UpdateBars();
    }
	public void UpdateBars ()
    {
        for (int i = 0; i < m_bars.Length; i++)
        {
            m_bars[i].transform.localScale = new Vector3 ( 1f, (0.2f + (i * 0.5f)), 1f);
            //m_bars[i].GetComponentInChildren<Image>().color = GameObject.FindGameObjectWithTag("ManagerP" + (i + 1)).GetComponent<Manager>().PlayerColor;
        }
    }
}
