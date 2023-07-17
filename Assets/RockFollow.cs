using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFollow : MonoBehaviour
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
    EnemyPathfinding enemyPathfinding;
    public bool SkillRock2 = false;
    public bool Skill1Rock = true;
     public bool Skill3Rock = false;
    RockSkill2 rockSkill2;
    RockSkill3 rockSkill3;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        rockSkill2 = GetComponent<RockSkill2>();
        rockSkill3 = GetComponent<RockSkill3>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        player = focusPlayer.transform;
        positionBoss = Boss.transform;
        StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill1Rock == true && SkillRock2 == false && Skill3Rock == false)
        {
            float DistancePlayer = Vector2.Distance(player.position, transform.position);
            if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
            {
                Speed = 5;
                myAnimator.SetBool("Attack", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);

            }
            else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
            {
                myAnimator.SetBool("Attack", true);
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
        else if (SkillRock2 == true && Skill1Rock == false && Skill3Rock == false)
        {
            rockSkill3.Attack();
        }
        else if (SkillRock2 == false && Skill1Rock == false && Skill3Rock == true)
        {
            float DistancePlayer = Vector2.Distance(player.position, transform.position);
            if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
            {   
                Speed = 5;
                myAnimator.SetBool("Attack2", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);

            }
            else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
            {
                myAnimator.SetBool("Attack2", true);
                myAnimator.SetBool("UnMutiple", true);
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


    }

    public void CheckAttack2(){
        enemyPathfinding.moveSpeed = 0;
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, 0 * Time.deltaTime);
        rockSkill2.Attack();
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(60);
        myAnimator.SetBool("Mutiple", true);
        yield return new WaitForSeconds(1);
        SkillRock2 = true;
        Skill1Rock = false;
        Skill3Rock = false;
        yield return new WaitForSeconds(40);
        myAnimator.SetBool("UnMutiple", true);
        myAnimator.SetBool("Forsure", true);
    }


    IEnumerator ReadyForSkillThree()
    {
        yield return new WaitForSeconds(4);
        myAnimator.SetBool("UnMutiple", false);
        myAnimator.SetBool("Forsure", false);
        Skill3Rock = true;
    }

    public void CheckAllreadyAttack()
    {
        enemyPathfinding.moveSpeed = 0;
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, 0 * Time.deltaTime);
        Instantiate(BulletFire, BulletParent.transform.position, Quaternion.identity);
        fireTime = Time.time + fireRate;
    }

    public void CheckAllreadyOpen()
    {
        SkillRock2 = false;
        Skill1Rock = false;
        StartCoroutine(ReadyForSkillThree());
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
