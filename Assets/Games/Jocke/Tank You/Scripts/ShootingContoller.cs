using UnityEngine;
using System.Collections;

public class ShootingContoller : MonoBehaviour {

    [SerializeField] private GameObject m_projectile;    

    private Transform m_barrelEnd;

    void Start()
    {
        m_barrelEnd = this.gameObject.transform.GetChild(0);
    }

	void Update () {
        if (Input.GetButtonDown("A_P1"))
        {
            GameObject newProjectile = (GameObject)Instantiate(m_projectile, m_barrelEnd.position, transform.rotation);
            Rigidbody rigidProjectile = newProjectile.GetComponent<Rigidbody>();
            rigidProjectile.AddForce(-transform.up * 10, ForceMode.Impulse);

            Destroy(newProjectile.gameObject, 3);
        }
	}
}
