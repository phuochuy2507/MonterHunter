using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missi : MonoBehaviour
{
    
    [SerializeField] private GameObject meteor;
    [SerializeField] private float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, meteor.transform.position, speed * Time.deltaTime);
        transform.up = meteor.transform.position - transform.position;
    }
}
