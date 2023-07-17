using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    // [SerializeField]
    // private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
   
    public static int EnemytoSpawn = 2;

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(EnemytoSpawn == 0) yield break;
        yield return new WaitForSeconds(interval);
        ManagerEnemies.no_of_enemies +=1;
        EnemytoSpawn -= 1;
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    private void Update() {

        
    }
}