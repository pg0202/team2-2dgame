using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float currentPosX;

    // Speed of camera
    public float lerpAmount = 1f;

    void FixedUpdate()
    {
        // Lerp camera to the new room
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(currentPosX, transform.position.y, -10), lerpAmount * Time.deltaTime);
    }

    // Set target position to the new room
    public void MoveToNewRoom(Transform newRoom)
    {
        currentPosX = newRoom.position.x;
    }
}
