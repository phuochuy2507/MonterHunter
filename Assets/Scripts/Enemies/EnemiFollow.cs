using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiFollow : MonoBehaviour
{
   [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject focusPlayer;
    [SerializeField]
    private GameObject Boss;
    private Transform player;
    private Transform positionBoss;
    [SerializeField]
    private float LineOfsite;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float ShootingRange;
    [SerializeField]
    private GameObject BulletFire;
    [SerializeField]
    private GameObject BulletParent;
    private Animator myAnimator;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float fireTime;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        player = focusPlayer.transform;
        positionBoss = Boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float DistancePlayer = Vector2.Distance(player.position, transform.position);
        if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);
             myAnimator.SetBool("Follow", true);
             myAnimator.SetBool("Attack", false);
        }
        else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
        {
            Instantiate(BulletFire, BulletParent.transform.position, Quaternion.identity);
            fireTime = Time.time + fireRate;
              myAnimator.SetBool("Attack", true);
        }
        else{
        myAnimator.SetBool("Follow", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfsite);
         Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }

    private void FixedUpdate()
    {
        if (player.position.x > positionBoss.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else{
             spriteRenderer.flipX = true;
        }

    }
}
