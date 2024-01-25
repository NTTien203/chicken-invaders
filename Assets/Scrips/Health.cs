using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] bool isPlayer;
    [SerializeField] GameObject Fchick;
     [SerializeField] GameObject gift;
    public int getHealth(){
        return health;
    }
    public void takeDamage(int damage){
        health-=damage;
            if(health<=0)
            {
                if(!isPlayer){
                    if(Random()==3){
                         GameObject Gilf=Instantiate(gift,transform.position,quaternion.identity);
                         if(gameObject.tag!=("enermies")){
                              Destroy(Gilf,4f);
                         }                     
                    }else{
                        GameObject friedChick=Instantiate(Fchick,transform.position,quaternion.identity);
                        if(gameObject.tag!=("enermies")){
                            Destroy(friedChick,4f);
                        }
                    }
                    
                }
                Destroy(gameObject);
            }
        
       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer=other.GetComponent<DamageDealer>();
        if(damageDealer!=null){
            damageDealer.hit();
            takeDamage(damageDealer.getDamage());
        }
    }
      int Random(){
       int random= UnityEngine.Random.Range(1 ,20);
        return random;
    }
}
