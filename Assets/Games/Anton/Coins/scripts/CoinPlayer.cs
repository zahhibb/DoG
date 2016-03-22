using UnityEngine;
using System.Collections;

public class CoinPlayer : MonoBehaviour {
    private Manager m_manager;
    private Rigidbody2D m_rb2d;
    static private float max_coins = 5;
    private float m_speed;
    private float m_coin;
    private bool m_shallDestroy;
    public void AssignManager(Manager manager)
    {
        m_manager = manager;
        GetComponent<SpriteRenderer>().color = m_manager.PlayerColor;
    }
    // Use this for initialization
    void Start() {
        m_coin = 0;
        m_speed = 5;
        m_rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            m_shallDestroy = true;
        }
    }
    public void SetPlayerPosition(Vector3 NewPosition)
    {
        transform.position = NewPosition;
    }
    public bool GetShallDestroy()
    {//returns if the player has hit enough coins
        return m_shallDestroy;
    }
    public void PickupCoin()
    {//called by the coin the player hits
        m_coin += 1;
        if (m_coin >= max_coins)
        {
            m_shallDestroy = true;
        }
    }
    public void SetScore(int score)
    {//sets the score of the player(used just before it is destroyed)
        m_manager.Score += score;
    }
// Update is called once per frame
void Update() {
        float y = -Input.GetAxis(m_manager.Inputs[13].name);

        float x = Input.GetAxis(m_manager.Inputs[12].name);

        m_rb2d.AddForce(new Vector2(x * m_speed, y * m_speed));

    }
    
}
