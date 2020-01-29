using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float movementSpeed = 10;//Speed we will move at
    float horizontal;//store in the inout from the user
    Rigidbody2D body;//rigid body to move the player
    Vector3 nextPostion;//where we are going next


    void Start ()
    {
        //get the rigid body from the game object
        body = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        //use Input.GetAxis to get the Horizontal input (A,D, Left Arrow, Right Arrow)
        //returns a value between -1 and 1 (-1 = moving left, 0 = not moving, 1 = moving right)
        horizontal = Input.GetAxis("Horizontal");

        //set our next position to be the direction we are moving * our speed * time pass since last update
        //movementSpeed * Time.deltaTime (moving a percentage of the speed every frame)
        nextPostion.x = horizontal * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //set the velocity of the object to move to our next position
        body.velocity = nextPostion;
    }
}
