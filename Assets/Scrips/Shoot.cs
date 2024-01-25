using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;

    [SerializeField] float bulletSpeed=2;
    [SerializeField] bool UseAI;
    public bool isFiring;
     static int bulletLV=0;
    Coroutine FiringCoroutine;
    [SerializeField] float randomRange;
     void Start(){
        if(UseAI){
            isFiring=true;
        }
    }
    
     void Update(){
       fire();
     }
      void fire(){
        if(isFiring && FiringCoroutine==null){
           FiringCoroutine= StartCoroutine(EggsIni());
        }else if(!isFiring && FiringCoroutine!=null){
            StopCoroutine(FiringCoroutine);
            //FiringCoroutine=null;
        }
        
    }
    public int getBulletLV(){
        return bulletLV;
    }
    public void setBulletLV(){
        bulletLV+=1;
    }
    public int CountBulletLV(){
        return bullet.Count();
    }
    
        public void BulletIni()
        {
        GameObject instance=Instantiate(bullet[ getBulletLV()],transform.position,Quaternion.identity);
        Rigidbody2D rb=instance.GetComponent<Rigidbody2D>();
        rb.velocity=transform.up*bulletSpeed;
        Destroy(instance,4f);
        }
     IEnumerator EggsIni(){
        while(true){
            GameObject instance=Instantiate(bullet[0],transform.position,Quaternion.identity);
            Rigidbody2D rb=instance.GetComponent<Rigidbody2D>();
            if(rb!=null){
                rb.velocity=transform.up*bulletSpeed;     
            }
           
            Destroy(instance,4f);
            yield return new WaitForSeconds( RamdomFiringRate());
       // }
        }
    }
    public  float RamdomFiringRate(){
        float FiringRateTime= UnityEngine.Random.Range(1 ,randomRange);
        return FiringRateTime;
    }

    
}
