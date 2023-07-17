using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeApear : MonoBehaviour
{
   [SerializeField]
    private GameObject SlimeBoss;
    private GameObject[] slimeEnemies;
    private bool currentEnemies = false;

    private void Start() {
        StartCoroutine(checkEnemies());
    }
    private void Update() {
       if (ManagerEnemies.no_of_enemies == 0 && currentEnemies == true)
       {
         SlimeBoss.SetActive(true);
       }
    }

    private IEnumerator checkEnemies(){
         yield return new WaitForSeconds(5);
         currentEnemies = true;


    } 
}
