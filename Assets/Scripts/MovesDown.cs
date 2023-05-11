using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDown : MonoBehaviour
{
    protected float speed = 5;
    protected PlayerController playerController;
    protected float bottomBound = -20;


    void Start()
    { 
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        //Moves Down
        MoveDown();

    }

    public virtual void MoveDown() {
        
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.y < bottomBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
