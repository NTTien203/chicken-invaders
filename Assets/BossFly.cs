using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BossFly : StateMachineBehaviour
{
    public float Speed=1;
    Transform player;
    Rigidbody2D rb;

    Health health;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player= GameObject.FindGameObjectWithTag("Player").transform;
        rb= animator.GetComponent<Rigidbody2D>();
        health=animator.GetComponent<Health>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target= new Vector2(player.position.x,2);

        Vector2 newPos=Vector2.MoveTowards(rb.position,target,Speed*Time.deltaTime);
        rb.MovePosition(newPos);

         if(health.getHealth()<=3500){
        
            animator.SetBool("Stun",true);
        }
    }
   

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
}
