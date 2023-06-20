using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemies : MonoBehaviour
{
    public static int no_of_enemies = 0;
    [SerializeField]
    public int nim;


    // Update is called once per frame
    void Update()
    {
        nim = no_of_enemies;
    }
}
