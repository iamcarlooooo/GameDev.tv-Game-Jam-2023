using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour { 

    [SerializeField] private float _movementSpeed = 2.0f;
    
    private Transform player;

    public Vector2 minRange = new Vector2(-50f, -50f);
    public Vector2 maxRange = new Vector2(50f, 50f);


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (IsWithinRange(player.position, minRange, maxRange))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, _movementSpeed * Time.deltaTime);
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
