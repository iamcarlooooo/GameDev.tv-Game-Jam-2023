using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour { 

    [SerializeField] private float _movementSpeed = 2.0f;
    
    private Transform player; 


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, _movementSpeed * Time.deltaTime);


    }
}
