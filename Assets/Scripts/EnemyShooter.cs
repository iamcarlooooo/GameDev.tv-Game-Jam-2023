using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _stoppingDistance = 20;
    [SerializeField] private float _retreatDistance = 10;

    private float _timeBtwShots;
    [SerializeField] private float startTimeBtwShots = 2;


    public GameObject EnemyShooterBullet;
    private Transform player;

    public Vector2 minRange = new Vector2(100f, -50f);
    public Vector2 maxRange = new Vector2(200f, 50f);


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {

        if (IsWithinRange(player.position, minRange, maxRange))
        {
            if (Vector2.Distance(transform.position, player.position) > _stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < _stoppingDistance && Vector2.Distance(transform.position, player.position) > _retreatDistance)
            {
                transform.position = transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < _retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
            }

            if (_timeBtwShots <= 0)
            {
                Instantiate(EnemyShooterBullet, transform.position, Quaternion.identity);
                _timeBtwShots = startTimeBtwShots;
            }
            else
            {
                _timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            transform.position = transform.position;

        }
    }

    private bool IsWithinRange(Vector2 position, Vector2 min, Vector2 max)
    {
        return position.x >= min.x && position.x <= max.x
            && position.y >= min.y && position.y <= max.y;
    }


}
