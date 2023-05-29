using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterBullet : MonoBehaviour
{

    [SerializeField] private float _speed = 20f;

    private Transform player;
    private Vector2 target;
    private GameObject PlayerObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyEnemyShooterBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            DestroyEnemyShooterBullet();
            Destroy(PlayerObject);
        }
        else if (other.CompareTag("Wall"))
        {
            DestroyEnemyShooterBullet();
        }
    }

    void DestroyEnemyShooterBullet ()
    {
        Destroy(gameObject);
    }
    
}
