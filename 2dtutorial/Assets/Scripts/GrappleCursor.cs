using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleCursor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Vector3 originalScale;

    private void Start()
    {
        //Get original scale of cursor for later reference
        originalScale = transform.localScale;
    }


    void Update()
    {
        // Get mouse position
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Set Cursor Position
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;


        // Shrink cursor when the player is holding the left mouse button
        if (Input.GetMouseButton(0))
        {
            transform.localScale = originalScale / 2;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GrapplingPoint"))
        {
            Debug.Log("grapple");
        }
    }
}
