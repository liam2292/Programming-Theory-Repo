using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MovesDown
{
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        MoveDown();

    }

    public override void MoveDown()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.down * 20 * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.y < bottomBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
