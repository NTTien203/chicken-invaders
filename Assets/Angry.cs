using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angry : StateMachineBehaviour
{
     public float Speed=1;
    Transform player;
    Rigidbody2D rb;
    [SerializeField] GameObject egg;
    [SerializeField] int randomRange;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
     public  float RamdomFiringRate(){
        float FiringRateTime= UnityEngine.Random.Range(1 ,randomRange);
        return FiringRateTime;
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player= GameObject.FindGameObjectWithTag("Player").transform;
        rb= animator.GetComponent<Rigidbody2D>();
    }

   //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target= new Vector2(player.position.x,player.position.y);

        Vector2 newPos=Vector2.MoveTowards(rb.position,target,Speed*Time.deltaTime);
        rb.MovePosition(newPos);
        if(RamdomFiringRate()==3){
            Instantiate(egg,rb.position,Quaternion.identity);
        }
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that processes and affects root motion
    }

    //OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that sets up animation IK (inverse kinematics)
    }
}
