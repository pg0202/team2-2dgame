using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public float speed;
    private float Move;

    //Jump Variables
    public float jump;
    public bool isOnGround;

    private Rigidbody2D rb;

    //Respawn Variable
    public Vector3 respawnPoint;

    void Start()
    {
        //
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }
    void Update()
    {
        Move = Input.GetAxis("Horizontal");


        if (Move != 0)
        {
            rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        }



        //rb.AddForce(new Vector3(speed * Move, 0).normalized, ForceMode2D.Force);




        if (Input.GetButtonDown("Jump") && isOnGround == true) //Apply Y velocity for the jump if isOnGround=true and button pressed
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Makes isOnGround statement to true after interacting with the "Ground" tag
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        
        //If player interacts with tag "Death" take 1 live away and set to respawn point
        if (other.gameObject.CompareTag("Death"))
        {
            transform.position = respawnPoint;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other) //sets isOnGround to false after exiting the collider
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    
    //Set the checkpoint into a respawn location after triggering with player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = other.gameObject.transform.position;
        }
    }
}