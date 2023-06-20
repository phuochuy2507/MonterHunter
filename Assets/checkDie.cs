using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemies.Length);
        CheckItemExistOrNot();
    }

    void CheckItemExistOrNot()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject == null)
            {
                Debug.Log("its null");
            }
            else
            {
                Debug.Log("its ok");
            }
        }
    }

    
}
