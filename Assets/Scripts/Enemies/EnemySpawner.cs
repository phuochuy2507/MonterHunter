using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;
    public int num_to_spawn = 20;
    public static int EnemytoSpawn;

    void Start()
    {
        EnemytoSpawn = num_to_spawn;
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        Debug.Log(EnemytoSpawn);
        yield return new WaitForSeconds(interval);
        if(EnemytoSpawn <= 0) yield break;
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized, Quaternion.identity);
        ManagerEnemies.no_of_enemies +=1;
        EnemytoSpawn -= 1;
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    private void Update() {

        
    }
}