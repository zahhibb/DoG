using UnityEngine;
using System.Collections;

public class ShootingContoller : MonoBehaviour {

    [SerializeField] private GameObject m_projectile;    
    private Transform m_barrelEnd;

    private float m_projectileForce = 7f;
    
    private string m_rightBumper;

    public string RightBumper
    {
        set { m_rightBumper = value; }
    }

    void Start()
    {        
        // Projectile instantiation point
        m_barrelEnd = this.gameObject.transform.GetChild(0);
    }

	void Update () {
        FireProjectile();
	}

    // Fire projectile and destroy it
    private void FireProjectile()
    {
        if (Input.GetButtonDown(m_rightBumper))
        {
            GameObject newProjectile = (GameObject)Instantiate(m_projectile, m_barrelEnd.position, transform.rotation);
            Rigidbody rigidProjectile = newProjectile.GetComponent<Rigidbody>();
            rigidProjectile.AddForce(-transform.up * m_projectileForce, ForceMode.Impulse);

            Destroy(newProjectile.gameObject, 3);
        }
    }
}
