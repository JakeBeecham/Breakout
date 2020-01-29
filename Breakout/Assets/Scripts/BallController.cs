using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movementSpeed = 10;
    float currentSpeed;
    Rigidbody2D body;
    Vector2 direction;

    //link the ball to the game manager
    public GameManager manager;

    //manager for playing sounds
    AudioSource audioSource;

    //what was the starting position of the ball?
    Vector3 startPosition;

    void Start()
    {
        //get the audio sourced attached to this game object
        audioSource = GetComponent<AudioSource>();

        body = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;

        //save the position at the start of the game in the variable startPosition
        startPosition = transform.position;

        ResetPosition();
        PickRandomDirection(70, 350);//pick the angles we want the ball to move
    }

    void ResetPosition()
    {
        body.MovePosition(startPosition);
    }

    void PickRandomDirection(float min, float max)
    {
        direction.x = Random.Range(min, max);
        direction.y = Random.Range(min, max);
        direction.Normalize();

        body.velocity = direction * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();

        //if the ball hits a block
        if (collision.gameObject.CompareTag("Block"))
        {
            //call the gamemanager to record the score
            //destroy the block that was hit
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Kill"))
        {
            //restart the ball (reset position and pick and new angle)
            ResetPosition();
            PickRandomDirection(40, 130);
        }
    }
}
