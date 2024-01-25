using System.Collections;
using System.Collections.Generic;
using System.IO;
using PathCreation;
using UnityEngine;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName = "Date", menuName = "ScriptableObjects/SpawnManagerScriptableObject")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject gameObject;
    [SerializeField] PathCreator pathCreator;
    [SerializeField] Transform startPoint;
    public PathCreator PathCreator(){
        return pathCreator;
    }
    public GameObject enermyPrefab(){
        return gameObject;
    }
    public Transform StartPoint(){
        return startPoint;
    }
    
}
