using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private Manager m_manager;
    private Rigidbody2D m_rb2d;
    private float m_speed;
    private bool m_shallDestroy;
    public void AssignManager(Manager manager)
    {
        m_manager = manager;
    }
    // Use this for initialization
    void Start() {
        Vector3 temp = transform.position;
        temp.z = 0.0f;
        transform.position = temp;//ensure all parts have same z value http://answers.unity3d.com/questions/600421/how-to-change-xyz-values-in-a-vector3-properly-in.html
        m_speed = 5;
        m_rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            print("blue");
            m_shallDestroy = true;
        }
    }
    public bool GetShallDestroy()
    {//returns if the player has hit a shot
        return m_shallDestroy;
    }
    public void SetShallDestroy()
    {//called by the shot the player hits
        m_shallDestroy = true;
    }
    public void SetScore(int score)
    {//sets the score of the player(used just before it is destroyed)
        m_manager.Score += score;
    }
// Update is called once per frame
void Update() {
        float x = Input.GetAxis(m_manager.Inputs[12].name);
        float y = -Input.GetAxis(m_manager.Inputs[13].name);

        m_rb2d.AddForce(new Vector2(x * m_speed, y * m_speed));

    }
    
}
