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
    [SerializeField]
    private int maxEnemy = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab, 0));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab, 0));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, int dem)
    {
        if(dem == maxEnemy) yield break;
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy, dem+1));
    }
}