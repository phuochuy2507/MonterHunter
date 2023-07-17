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
    private Animator myAnimator;
    [SerializeField]
    private float ShootingRange;
    [SerializeField]
    private float fireTime;
    [SerializeField]
    private Transform swordOfRed;

    public bool doneWakeUp = false;
    public bool checkNearEnemies;
    EnemyPathfinding enemyPathfinding;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
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
                myAnimator.SetBool("Attack", false);
                Debug.Log("follow him");
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);

            }
            else if (DistancePlayer <= ShootingRange)
            {
                myAnimator.SetBool("Attack", true);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, 0 * Time.deltaTime);
                enemyPathfinding.moveSpeed = 0;
                if (player.position.x > positionBoss.position.x)
                {
                    spriteRenderer.flipX = false;
                    swordOfRed.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    spriteRenderer.flipX = true;
                    swordOfRed.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
        }
        else
        {
            Debug.Log("not follow or attack");
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
