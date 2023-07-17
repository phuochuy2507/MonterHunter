using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRock : MonoBehaviour
{
    [SerializeField]
  private Vector2 direction = new Vector2(1, 0);
  [SerializeField]
  private float speed = 2;
  [SerializeField]
  private Vector2 velocity;

  private void Start() {
    Destroy(gameObject, 3);
  }

  private void Update() {
    velocity = direction * speed;
  }

  private void FixedUpdate() {
    Vector2 pos = transform.position;
    pos += velocity * Time.fixedDeltaTime;
    transform.position = pos;
  }
}
