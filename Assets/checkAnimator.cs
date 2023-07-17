using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAnimator : MonoBehaviour
{
     [SerializeField]
    private float speed;
    private Transform player;
    Animator _animation;
    private bool shouldTheyRun;

    private void Start() {
        _animation = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Ham follow theo player
     public void MoveBoss()
    {
      transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
    }
    // This will check when the animation wakeup complete
    public void AllreadyWakeUp()
    {
        shouldTheyRun = true;
    }

    private void Update() {
        Debug.Log(transform.position);
        if (shouldTheyRun == true)
        {   
            _animation.SetBool("Follow", true);
            MoveBoss();
        }
    }
}
