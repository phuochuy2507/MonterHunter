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
    public bool checkRockSkill2 = false;
    public bool Skill1Rock = true;
    RockSkill2 rockSkill2;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        rockSkill2 = GetComponent<RockSkill2>();
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
        if (Skill1Rock == true &&  checkRockSkill2 == false)
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
        else if (checkRockSkill2 == true && Skill1Rock == false)
        {
            rockSkill2.Attack();
        }


    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(10);
        myAnimator.SetBool("Mutiple", true);
        yield return new WaitForSeconds(1);
        checkRockSkill2 = true;
        Skill1Rock = false;
        yield return new WaitForSeconds(30);
         myAnimator.SetBool("UnMutiple", true);
    }


      IEnumerator ReadyForSkillThree(){
         yield return new WaitForSeconds(50);
      }

    public void CheckAllreadyAttack()
    {
        enemyPathfinding.moveSpeed = 0;
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, 0 * Time.deltaTime);
        Instantiate(BulletFire, BulletParent.transform.position, Quaternion.identity);
        fireTime = Time.time + fireRate;
    }

    public void CheckAllreadyOpen(){
        myAnimator.SetBool("UnMutiple", false);
        myAnimator.SetBool("Mutiple", false);
         checkRockSkill2 = false;
        Skill1Rock = true;
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
