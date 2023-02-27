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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distJoint = GetComponent<DistanceJoint2D>();
        lineRend = GetComponent<LineRenderer>();

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

        // 1 = Connects player to grapple point and lets them swing
        if (selectedPoint.grapplingPointType == 0)
        {
            distJoint.connectedBody = selectedPoint.GetComponent<Rigidbody2D>();
            distJoint.enabled = true;
        }
        // 2 = Propels player towards grappling point
        else
        {
            rb.velocity = Vector3.zero;
            rb.AddForce((selectedPoint.transform.position - transform.position).normalized * grappleStrength);
        }
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
