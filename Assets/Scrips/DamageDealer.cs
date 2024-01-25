using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealer=10;
    public int getDamage(){
        return damageDealer;
    }
    public void setDamage(int plus){
        damageDealer+=plus;
    }
    public void hit(){
        Destroy(gameObject);
    }
}
