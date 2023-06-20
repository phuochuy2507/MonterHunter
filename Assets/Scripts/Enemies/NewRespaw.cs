using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespaw : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemies;
    [SerializeField]
    private int numberEnemies;
    [SerializeField]
    public List<GameObject> allEnemies;
    EnemyHealth emh = new EnemyHealth();
    private void Start() {
       render();
    }
    private void Update()
    {
    }

    private void render()
    {
        for (var i = 0; i < numberEnemies; i++)
        {
            var a = (Instantiate(Enemies, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized, Quaternion.identity));
            allEnemies.Add(a);
        }
    }

    private void checkArr(){
     if (emh.checkAllDie())
     {
        Debug.Log("hi");
     }
     else{
        Debug.Log("hello");
     }
    }
}
