using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private PlayerMovement player;

    public float currentPosX;

    private float playerCurrentPosX;
    private float playerCurrentPosY;

    // Speed of camera
    public float lerpAmount = 1f;

    public float playerLerpAmount = 1f;

    void FixedUpdate()
    {
        // Lerp camera to the new room
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(currentPosX, transform.position.y, -10), lerpAmount * Time.deltaTime);

        // Lerp player to next room
        if (Mathf.Round(transform.position.x) != Mathf.Round(currentPosX))
        {
            player.transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, playerCurrentPosY, 0), new Vector3(playerCurrentPosX, playerCurrentPosY, 0), playerLerpAmount * Time.deltaTime);
        }


    }

    // Set target position to the new room
    public void MoveToNewRoom(Transform newRoom)
    {
        currentPosX = newRoom.position.x;

        if (player.transform.position.x < newRoom.position.x)
        {
            playerCurrentPosX = player.transform.position.x + 3;
            playerCurrentPosY = player.transform.position.y;
        }
        else
        {
            playerCurrentPosX = player.transform.position.x - 3;
            playerCurrentPosY = player.transform.position.y;
        }

    }
}
