using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject objectSpawn;

    void SpawnOject()
    {
        GameObject newObject = Instantiate(objectSpawn);
    }
   
    void Start()
    {
  Instantiate(objectSpawn, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
