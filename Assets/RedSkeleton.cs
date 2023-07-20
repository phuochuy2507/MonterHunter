using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSkeleton : MonoBehaviour
{
    [SerializeField]
    private GameObject redSkeleton;
    private GameObject[] boneEnemies;
    private void Start()
    {
    }
    private void Update()
    {
        boneEnemies = GameObject.FindGameObjectsWithTag("BoneEnemies");
        if (boneEnemies.Length == 0)
        {
            redSkeleton.SetActive(true);
            enabled = false;
        }
    }

 
}
