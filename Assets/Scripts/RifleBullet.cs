using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
    
   }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        
        if (other.tag == "EnemyMelee") {
            Destroy(other.gameObject);
        }
        else if (other.tag == "EnemyShooter")
        {
            Destroy(other.gameObject);
        }
    }
}
