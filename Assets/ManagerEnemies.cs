using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemies : MonoBehaviour
{
    public static int no_of_enemies;
    [SerializeField]
    public int nim;


    private void Start()
    {
        no_of_enemies = 1;
    }
    // Update is called once per frame
    void Update()
    {
        nim = no_of_enemies;
    }
}
