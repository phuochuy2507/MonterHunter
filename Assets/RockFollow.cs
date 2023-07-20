using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFollow : MonoBehaviour
{

    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject Boss;
    private GameObject player;
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
    EnemiesHealthBar enemiesHealthBar;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        rockSkill2 = GetComponent<RockSkill2>();
        rockSkill3 = GetComponent<RockSkill3>();
        myAnimator = GetComponent<Animator>();
        enemiesHealthBar = GetComponent<EnemiesHealthBar>();
    }
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("haha");
        player = GameObject.FindGameObjectWithTag("Player");
        positionBoss = Boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill1Rock == true && SkillRock2 == false && Skill3Rock == false)
        {
            checkSkill();
            float DistancePlayer = Vector2.Distance(player.transform.position, transform.position);
            if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
            {

                Speed = 5;
                myAnimator.SetBool("Attack", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);

            }
            else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
            {

                myAnimator.SetBool("Attack", true);
                if (player.transform.position.x > positionBoss.position.x)
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
            if (enemiesHealthBar.currentHealth <= 60)
            {
                myAnimator.SetBool("UnMutiple", true);
                myAnimator.SetBool("Forsure", true);
            }
            else
            {
                rockSkill3.Attack();
            }
        }
        else if (SkillRock2 == false && Skill1Rock == false && Skill3Rock == true)
        {
            if (enemiesHealthBar.currentHealth <= 0)
            {
                if ( !FindObjectOfType<AudioManager>().IsPlaying("BossDie"))
                {
                    FindObjectOfType<AudioManager>().Play("BossDie");
                        FindObjectOfType<AudioManager>().Stop("Angry");
                }
               else
               {
                myAnimator.SetBool("DieRock", true);
               }
            }
            else
            {
                float DistancePlayer = Vector2.Distance(player.transform.position, transform.position);
                if (DistancePlayer < LineOfsite && DistancePlayer > ShootingRange)
                {
                    Debug.Log("follow");
                    Speed = 5;
                    myAnimator.SetBool("Attack2", false);
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);

                }
                else if (DistancePlayer <= ShootingRange && fireTime < Time.time)
                {
                    myAnimator.SetBool("Attack2", true);
                    myAnimator.SetBool("UnMutiple", true);
                    if (player.transform.position.x > positionBoss.position.x)
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

    }


    public void CheckAttack2()
    {
        enemyPathfinding.moveSpeed = 0;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 0 * Time.deltaTime);
        rockSkill2.Attack();
    }


    IEnumerator WaitForSkill()
    {
        yield return new WaitForSeconds(1);
        if (FindObjectOfType<AudioManager>().IsPlaying("Growing"))
        {
            yield break;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Growing");
            SkillRock2 = true;
            Skill1Rock = false;
            Skill3Rock = false;
        }

    }

    private void checkSkill()
    {
        if (enemiesHealthBar.currentHealth <= 130)
        {
            myAnimator.SetBool("Mutiple", true);
            StartCoroutine(WaitForSkill());
        }

    }

    public void theBossDie()
    {
        enabled = false;
        FindObjectOfType<AudioManager>().Stop("BossDie");
        Destroy(gameObject);
    }

    public void CheckAllreadyAttack()
    {
        enemyPathfinding.moveSpeed = 0;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 0 * Time.deltaTime);
        FindObjectOfType<AudioManager>().Play("bossSkillOne");
        Instantiate(BulletFire, BulletParent.transform.position, Quaternion.identity);
        fireTime = Time.time + fireRate;
    }

    public void CheckAllreadyOpen()
    {
        SkillRock2 = false;
        Skill1Rock = false;
        FindObjectOfType<AudioManager>().Stop("Growing");
        StartCoroutine(ReadyForSkillThree());
    }

    IEnumerator ReadyForSkillThree()
    {
        yield return new WaitForSeconds(2);

        if (FindObjectOfType<AudioManager>().IsPlaying("Angry"))
        {
            yield break;
        }
        else
        {
            myAnimator.SetBool("UnMutiple", false);
            myAnimator.SetBool("Forsure", false);
            FindObjectOfType<AudioManager>().Play("Angry");
            Skill3Rock = true;
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
        if (player.transform.position.x > positionBoss.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

    }
}
