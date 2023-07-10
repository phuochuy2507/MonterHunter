using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFind : MonoBehaviour
{
     GameObject targer;
    [SerializeField]
    private float speed;
    Rigidbody2D bulletRB;


    // Update is called once per frame
  private void Start() {
    bulletRB = GetComponent<Rigidbody2D>();
    targer = GameObject.FindGameObjectWithTag("Player");
    Vector2 moveDir = (targer.transform.position - transform.position).normalized * speed;
    transform.up = targer.transform.position - transform.position;
    bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    Destroy(this.gameObject, 2);
  }
}
