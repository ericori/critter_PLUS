using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public missionController mission;
    public MiniGame miniGame;
    //public MiniGame miniGame;
    private bool grab = false;
    private Vector3 offset;
    private Vector3 startPosition;

    void Start()
    {
        mission = FindAnyObjectByType<missionController>();
        miniGame = FindAnyObjectByType<MiniGame>();
        miniGame.hideMe.Add(this.gameObject);
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

        if (other.gameObject.name == "mouth")
        {
            //Debug.Log("Detected doggy");
            if (grab)
            {
                grab = false;
                //for mission increment
                mission.missionDistributer("Play");
                miniGame.setUp();
            }
            else
            {
                //Debug.Log("Brush is over doggy but not grabbed.");
            }
        }
    }
}
