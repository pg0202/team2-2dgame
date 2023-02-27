using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleCursor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;


    void Update()
    {
        // Get mouse position
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Set Cursor Position
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GrapplingPoint"))
        {
            Debug.Log("grapple");
        }
    }
}
