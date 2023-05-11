using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    private float horizontalInput;
    private float xRange = 14;
    private float speed = 20.0f;
    private int lives = 3;

    void Update(){
         if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
        
    }

    public void OnCollisionEnter(Collision other){
        DealDamage(other);
        if(lives == 0) {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }

    private void DealDamage(Collision other) {
        if (other.gameObject.CompareTag("Carrot"))
        {
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Apple"))
        {
            //temp until character select implemented
            lives -= 1;
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Bone")) {
            //temp
            lives -= 1;
            Destroy(other.gameObject);
        }
        
    }
}
