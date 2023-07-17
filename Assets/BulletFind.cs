using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFind : MonoBehaviour
{
    //    GameObject targer;
    //   [SerializeField]
    //   private float speed;
    //   Rigidbody2D bulletRB;


    //   // Update is called once per frame
    // private void Start() {
    //   bulletRB = GetComponent<Rigidbody2D>();
    //   targer = GameObject.FindGameObjectWithTag("Player");
    //   Vector2 moveDir = (targer.transform.position - transform.position).normalized * speed;
    //   transform.up = targer.transform.position - transform.position;
    //   bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    //   Destroy(this.gameObject, 2);
    // }
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
     [SerializeField] private GameObject particleOnHitPrefabVFX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    }

  

