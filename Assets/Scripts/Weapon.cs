using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject rifleBulletPrefab;
    public Transform firePoint;
    public float fireForce = 100f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject RifleBullet = Instantiate(rifleBulletPrefab, firePoint.position, firePoint.rotation);
        RifleBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
