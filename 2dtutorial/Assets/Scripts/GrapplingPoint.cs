using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingPoint : MonoBehaviour
{
    private GameObject player;
    private Grapple grappleScript;

    private GrapplingPoint grapplingPoint;

    // Type of grapple point
    public int grapplingPointType = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grapplingPoint = null;

        // Get players Grapple Script
        player = GameObject.FindGameObjectWithTag("Player");
        grappleScript = player.GetComponent<Grapple>();
    }

    // On click, select the grappling point
    private void OnMouseDown()
    {
        grapplingPoint = this;
        grappleScript.SelectGrapplingPoint(grapplingPoint);
    }

    //On release, deselect grappling point
    private void OnMouseUp()
    {
        grappleScript.DeselectGrapplingPoint();
    }

}
