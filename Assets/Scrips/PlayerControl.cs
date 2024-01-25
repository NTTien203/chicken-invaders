using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using Unity.VisualScripting;

public class PlayerControl : MonoBehaviour
{
     private Camera mainCamera;
      Shoot shoot;
     Vector2 minbound;
     Vector2 maxbound;
     [SerializeField] float paddingLeft;
     [SerializeField] float paddingRight;
     [SerializeField] float paddingTop;
     [SerializeField] float paddingUnder;
      DamageDealer damage;
    void Start()
    {
        shoot=GetComponent<Shoot>();
        damage=GetComponent<DamageDealer>();
        mainCamera=Camera.main;
        minbound=mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxbound=mainCamera.ViewportToWorldPoint(new Vector2(1,1));
        
    }
    void followMouse(){
        Vector2 newpos;
        newpos.x=math.clamp(getWorldPositionFromMouse().x,minbound.x+paddingLeft,maxbound.x-paddingRight);
        newpos.y=math.clamp(getWorldPositionFromMouse().y,minbound.y+paddingUnder,maxbound.y-paddingTop);
        transform.position=newpos;
    }
     Vector2 getWorldPositionFromMouse(){
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnFire(InputValue value){
         shoot.BulletIni();
    }   
    void OnRocket(InputValue value){
        GameObject[] enermy = GameObject.FindGameObjectsWithTag("Enermies");
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("eggs");
         GameObject[] enermies = GameObject.FindGameObjectsWithTag("enermies");
        foreach(GameObject go in enermy){
            var health=go.GetComponent<Health>();
            health.takeDamage(health.getHealth());
            
        }
        foreach(GameObject go in eggs){
            Destroy(go);
        }
          foreach(GameObject go in enermies){
            var health=go.GetComponent<Health>();
            health.takeDamage(health.getHealth());
            
        }
      
    }
    void Update()
    {
        followMouse();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Score score=other.GetComponent<Score>();
        if(score!=null)
        {
            if(score.tag=="FriedChick"){
                score.hit();
                score.setCurrentChick();
                Debug.Log(score.getCurrentChick());
            }else if(score.tag=="Gift"){
                if(shoot.getBulletLV()<(shoot.CountBulletLV()-1)){
                    score.hit();
                    shoot.setBulletLV();
                }
                score.hit();
                
            }
           
        }
    }
 }
    

