using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private Manager m_manager;
    private Rigidbody2D m_rb2d;
    private float m_speed;
    public void AssignManager(Manager manager)
    {
        m_manager = manager;
    }
    // Use this for initialization
    void Start () {
        m_speed = 1;
        m_rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis(m_manager.Inputs[6].name);
        float y = Input.GetAxis(m_manager.Inputs[7].name);
        m_rb2d.AddForce(new Vector2(x*m_speed,y*m_speed));

    }
}
