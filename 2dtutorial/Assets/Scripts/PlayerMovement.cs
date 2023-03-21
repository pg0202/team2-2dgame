using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;

    public float jump;
    public bool isOnGround;

    private Rigidbody2D rb;

    public Vector3 respawnPoint;
    void Start()
    {
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




        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (other.gameObject.CompareTag("Death"))
        {
            transform.position = respawnPoint;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = other.gameObject.transform.position;
            Debug.Log("YES");
        }
    }
}