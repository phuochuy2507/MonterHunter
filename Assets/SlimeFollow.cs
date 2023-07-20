using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFollow : MonoBehaviour
{
   [SerializeField]
    private float Speed;
    private GameObject focusPlayer;
    [SerializeField]
    private GameObject Boss;
    private GameObject player;
    private Transform positionBoss;
    [SerializeField]
    private float LineOfsite;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    EnemyPathfinding enemyPathfinding;
     private  Renderer m_ObjectRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        myAnimator = GetComponent<Animator>();
        //  m_ObjectRenderer = GetComponent<Renderer>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        positionBoss = Boss.transform;
        // m_ObjectRenderer.material.renderQueue = 2999;
    }


    // Update is called once per frame
    void Update()
    {

        float DistancePlayer = Vector2.Distance(player.transform.position, transform.position);
        if (DistancePlayer < LineOfsite)
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfsite);
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
