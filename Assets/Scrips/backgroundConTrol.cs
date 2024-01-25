using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class backgroundConTrol : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Material material;
    Vector2 offset;
    
     private void Awake() {
            material= GetComponent<SpriteRenderer>().material;
    }
   

    // Update is called once per frame
    void Update()
    {
        offset=moveSpeed*Time.deltaTime;
        material.mainTextureOffset+=offset;
    }
}
