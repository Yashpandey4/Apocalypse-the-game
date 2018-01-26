using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
   public GameObject bombs;                
    public float spawnTime = 3f;            
    public Transform[] spawnPoints;         


    void Start ()
    {
        
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
    

        
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        
        Instantiate (bombs, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
