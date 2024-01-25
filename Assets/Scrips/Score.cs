using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{   
    static int currentChick=0;
   
   public void hit(){
    Destroy(gameObject);
   }
   public int getCurrentChick(){
        return currentChick;
   }
   public void setCurrentChick(){
     currentChick+=1;
   }

}
