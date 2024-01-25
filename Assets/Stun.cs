using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stun : StateMachineBehaviour
{
    [SerializeField] GameObject egg;
    Rigidbody2D rb;
     Health health;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb=animator.GetComponent<Rigidbody2D>();
         circleFormation();
         health=animator.GetComponent<Health>();
    }
    void circleFormation(){
        Vector2 targetPosition=Vector2.zero-new Vector2(1.2f,1);
        for(int i=0;i<10;i++){
            Instantiate(egg,targetPosition,quaternion.identity);
            float angle=i*(2*3.14159f/10);
            float x=Mathf.Cos(angle)*2f;
            float y=Mathf.Sin(angle)*2f;
            targetPosition=new Vector2(targetPosition.x+ x,targetPosition.y+y);
            
        }
    }
   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Vector2 newPos=Vector2.MoveTowards(rb.position,new Vector2(0,2),10*Time.deltaTime);
        rb.MovePosition(newPos);
          if(health.getHealth()<=2500){
            animator.SetBool("Angry",true);
        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
