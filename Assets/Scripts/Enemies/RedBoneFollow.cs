using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoneFollow : MonoBehaviour
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
    public bool doneWakeUp;
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

    public void CheckAnimationDone()
    {
        doneWakeUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (doneWakeUp == true)
        {
             float DistancePlayer = Vector2.Distance(player.position, transform.position);
        if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
        {
             myAnimator.SetBool("Follow", true);
            Debug.Log("follow him");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);
            
        }
        else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
        {
            Debug.Log("kill him");
             myAnimator.SetBool("Attack", true);
        }
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
        else
        {
            spriteRenderer.flipX = true;
        }

    }
}
