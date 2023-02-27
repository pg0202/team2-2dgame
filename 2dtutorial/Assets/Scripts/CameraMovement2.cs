using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    public GameObject target;
    public float lerpAmount = 1f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(target.transform.position.x, target.transform.position.y, -10), lerpAmount * Time.deltaTime);
    }
}
