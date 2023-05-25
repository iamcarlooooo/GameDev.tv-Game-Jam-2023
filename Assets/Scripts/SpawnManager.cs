using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _enemyMeleePrefab;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

   
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine ()
    {
      while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-50, 59), Random.Range(-50, 50));
            Instantiate(_enemyMeleePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
