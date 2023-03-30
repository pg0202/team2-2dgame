using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Check if player has collided with the trigger and destroy the object
        {
            FindObjectOfType<CoinManagement>().CoinPickup();
            Destroy(gameObject);
        }
    }
}
