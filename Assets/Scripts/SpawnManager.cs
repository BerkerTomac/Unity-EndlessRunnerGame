using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spawnpos = new Vector3(25, 0, 0);

    private float startTime = 2;
    // private float repeatTime = 2f;
   

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    { 
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", startTime, Random.Range(1.2f,2f));

    }

    // Update is called once per frame
    void Update()
    {

 
    }

   


    void spawnObstacle()
    {
       if(playerController.isGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnpos, obstaclePrefab.transform.rotation);
        }
        
    }
}
