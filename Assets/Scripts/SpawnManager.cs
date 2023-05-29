using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyMeleePrefab;
    [SerializeField] private GameObject _enemyShooterPrefab;
    private Transform player;

    [SerializeField] private Vector2 minRangeOfZA = new Vector2(-50f, -50f);
    [SerializeField] private Vector2 maxRangeOfZA = new Vector2(50f, 50f);

    [SerializeField] private Vector2 minRangeOfAW = new Vector2(100f, -50f);
    [SerializeField] private Vector2 maxRangeOfAW = new Vector2(200f, 50f);

    private Coroutine meleeCoroutine;
    private Coroutine shooterCoroutine;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        meleeCoroutine = StartCoroutine(SpawnRoutineEnemyMelee());
        

    }

    void Update()
    {
        // Check if the player is within the specified range
        bool isWithinRangeOfZA = IsWithinRange(player.position, minRangeOfZA, maxRangeOfZA);
        bool isWithinRangeOfAW = IsWithinRange(player.position, minRangeOfAW, maxRangeOfAW);

        if (isWithinRangeOfZA && meleeCoroutine == null)
        {
            meleeCoroutine = StartCoroutine(SpawnRoutineEnemyMelee());
        }
        
        else if (isWithinRangeOfAW && meleeCoroutine != null)
        {
            StopCoroutine(meleeCoroutine);
            meleeCoroutine = null;
            shooterCoroutine = StartCoroutine(SpawnRoutineEnemyShooter());
        }
        else if (isWithinRangeOfZA && meleeCoroutine != null && shooterCoroutine != null)
        {
            StopCoroutine(shooterCoroutine);
            shooterCoroutine = null;
            meleeCoroutine = StartCoroutine(SpawnRoutineEnemyMelee());
         
        }
    }

    IEnumerator SpawnRoutineEnemyMelee()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
            Instantiate(_enemyMeleePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SpawnRoutineEnemyShooter()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(100, 200), Random.Range(-50, 50));
            Instantiate(_enemyShooterPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private bool IsWithinRange(Vector2 position, Vector2 min, Vector2 max)
    {
        return position.x >= min.x && position.x <= max.x
            && position.y >= min.y && position.y <= max.y;
    }
}
