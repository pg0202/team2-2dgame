using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private Rigidbody2D rb;

    private GrapplingPoint selectedPoint;

    public float grappleStrength = 500f;

    private DistanceJoint2D distJoint;
    private LineRenderer lineRend;

    void Start()
    {
        // Grab Components
        rb = GetComponent<Rigidbody2D>();
        distJoint = GetComponent<DistanceJoint2D>();
        lineRend = GetComponent<LineRenderer>();

        // Disable distance joint, line render and make the selected point nothing
        selectedPoint = null;
        distJoint.enabled = false;
        lineRend.enabled = false;
    }

    void Update()
    {
        GrappleBehaviour();
    }

    // Grapple onto a grappling point
    public void SelectGrapplingPoint(GrapplingPoint grapplingPoint)
    {
        selectedPoint = grapplingPoint;

        // Determine which type of grappling point the object is

        // 0 = Connects player to grapple point and lets them swing
        if (selectedPoint.grapplingPointType == 0)
        {
            distJoint.connectedBody = selectedPoint.GetComponent<Rigidbody2D>();
            distJoint.enabled = true;
        }
        // 1 = Propels player towards grappling point
        else if (selectedPoint.grapplingPointType == 1)
        {
            rb.velocity = Vector3.zero;
            // Adds force, making it not normalized makes the strength of the force be proportional to the distance from the grappling point
            rb.AddForce((selectedPoint.transform.position - transform.position).normalized * grappleStrength);
        }
        // 2 = Propels player away from grappling point
        else if (selectedPoint.grapplingPointType == 2)
        {
            rb.velocity = Vector3.zero;
            // Adds force, making it not normalized makes the strength of the force be proportional to the distance from the grappling point
            rb.AddForce((selectedPoint.transform.position - transform.position).normalized * -grappleStrength);
        }


        //4 = makes distance joint really close to the grappling point - Fixed distance from swing
    }

    // Ungrapple from a grappling point
    public void DeselectGrapplingPoint()
    {
        selectedPoint = null;
        distJoint.enabled = false;
    }


    private void GrappleBehaviour()
    {
        // If grappling, create Line between player and grappling point
        if (selectedPoint != null)
        {
            // Enable Line render
            lineRend.enabled = true;
            // Draw Line from player to Grappling point
            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, selectedPoint.transform.position);
        }
        else
        {
            // Disable Line renderer
            lineRend.enabled = false;
        }
    }
}
