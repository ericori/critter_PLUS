using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    private bool grab = false;
    private Vector3 offset;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (grab)
        {
            // Convert mouse position to world position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure there is no z-axis offset since we are working in 2D
            transform.position = mousePos + offset;
            //Debug.Log("Mouse Position: " + mousePos);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    void OnMouseDown()
    {
        // Calculate offset from brush center to mouse click position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure z position is flattened for 2D
        offset = transform.position - mousePos;
        grab = true;
        //Debug.Log("Grabbing the brush.");
    }

    void OnMouseUp()
    {
        grab = false;
        //Debug.Log("Released the brush.");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Currently colliding with: " + other.gameObject.name);

        if (other.gameObject.name == "doggy")
        {
            //Debug.Log("Detected doggy");
            if (grab)
            {
                //Debug.Log("Brush is over doggy and moving.");
                Vector3 brushingPosition = transform.position;
                brushingPosition.z = 0;
                other.GetComponent<petInteractivity>().AddAffectionWhileBrushing(brushingPosition);
                //other.GetComponent<petInteractivity>().AddAffectionWhileBrushing();
            }
            else
            {
                //Debug.Log("Brush is over doggy but not grabbed.");
            }
        }
    }
}