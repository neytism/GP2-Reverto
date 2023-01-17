using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5f;
    [SerializeField] private float _timeInterval = 1f;

    //public GameObject[] enemies;  CAN BE USED FOR MULTIPLE ENEMIES
    [SerializeField] private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayBeforeSpawning());
        StartCoroutine(SpawnEnemy());  //can be commented
    }

    IEnumerator SpawnEnemy()  //spawns enemy based on radius around player
    {
        Vector2 spawnPos = FindObjectOfType<PlayerMovement>().transform.position;
        spawnPos += Random.insideUnitCircle.normalized * _spawnRadius;
        
        GameObject enemy = ObjectPool.Instance.GetObject(_enemyPrefab, spawnPos);
        enemy.SetActive(true);
        
        yield return new WaitForSeconds(_timeInterval);
        StartCoroutine(SpawnEnemy());  //loops
    }


    IEnumerator DelayBeforeSpawning()   //adds delay to show mini tutorial pop up
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnEnemy());
    }
}
