using System.Collections;
using System.Collections.Generic;
using System.Threading;
using PathCreation;
using PathCreation.Examples;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  
    public List<GameObject> enermies=new List<GameObject>();
    public int rows = 5;
    public int columns = 5;
    public float spacing = 2f;

  

    [SerializeField]List<WaveConfig> waveConfig;
    [SerializeField] float speed=15;
    [SerializeField] GameObject bossPrefab;

    
     int wave=0;
     private void Awake() {
     }
    void Start()
    {
         // StartCoroutine(CreateFormation());  
          // bossSpawn();
    }
    void bossSpawn(){
       Vector2 targetPosition=Vector2.zero;
      if(wave==waveConfig.Count && enermies.Count==0){
        Instantiate(bossPrefab,targetPosition,quaternion.identity);
        wave++;
      }
    }

    private  IEnumerator  CreateFormation()
    {
        
     do{
      
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
              GameObject a =Instantiate(waveConfig[wave].enermyPrefab(), 
                                        waveConfig[wave].StartPoint().transform.position,
                                         Quaternion.Euler(0,0,0),
                                         transform);
              a.transform.parent=transform;
               enermies.Add(a);
               yield return new WaitForSeconds(0.2f);
             // a.SetActive(false);
              }
        }
       /* for(int i=0;i<enermies.Count;i++){
           // enermies[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }*/
        wave++;
     }while(enermies.Count==0);
    }
    
    void countEnermies()
    {
      int count=0;
      if(enermies.Count!=0)
      {
       for(int i=0;i<enermies.Count;i++)
       {
        if(enermies[i]==null)
        {
          count++;
        }
        if(count==30)
        {
          enermies.Clear();
          count=0;
        }
      }
     } 
    }
  void armyFormat(){
      int index=0;
      for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
              Debug.Log(index);
                     if(index<enermies.Count && enermies[index]!=null){
                      Vector3 position = new Vector3(col * spacing-10,  row * spacing,0f);
                        enermies[index].transform.position=Vector2.MoveTowards(enermies[index].transform.position,position,speed*Time.deltaTime);
                        index++;  
                     }else{
                        index++;
                     }
              
                    
            }
        }
    }

  /*  void armyFormat()
{
    int index = 0;
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < columns; col++)
        {
            Debug.Log(index);
            if (index < enermies.Count && enermies[index] != null)
            {
                Vector3 position = new Vector3(col * spacing - 10, row * spacing, 0f);
                enermies[index].transform.position = Vector2.MoveTowards(enermies[index].transform.position, position, speed * Time.deltaTime);
            }
            index++;
        }
    }
}*/

    // Update is called once per frame
    
    void Update()
    {
      if(enermies.Count==0 && wave<=waveConfig.Count){
        StartCoroutine(CreateFormation()); 
      }
       bossSpawn();
      countEnermies();
      armyFormat();
    }
}
