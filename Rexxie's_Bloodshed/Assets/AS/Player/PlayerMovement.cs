using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    int souls = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int tempSouls = FindObjectOfType<Collectables>().souls;
        if (tempSouls > souls)
        {
            moveSpeed ++;
            souls = tempSouls;
        }
        //check for user imput for top-down movement
        //vertical and horizontal directional input
        //horizontal - x input = a, d
        //if the A key is pressed, give a value moving towards -1
        //if the D key is pressed, give a value moving towards +1
        float moveX = Input.GetAxis("Horizontal");
        //vertical = y input = w, s
        //if the S key is pressed, give a value moving towards -1
        //if the W key is pressed, give a value moving towards +1
        float moveY = Input.GetAxis("Vertical");
        //push the player in the direction of the user input
        //use the rigidbody to push the player around
        //create a new moveDirection varible to combine x, y input
        Vector2 moveDir = new Vector2(moveX, moveY);
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
}