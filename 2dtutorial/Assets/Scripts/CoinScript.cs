using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip coinPickupSound;
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position);
            FindObjectOfType<GameManagementScript>().CoinPickup();
            Destroy(gameObject);
        }
    }
}
