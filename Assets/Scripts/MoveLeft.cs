using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 20.0f;

    private float boundary = -15;

    private PlayerController playerContollerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(playerContollerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < boundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        
    }
}
