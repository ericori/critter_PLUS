using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private bool grab = false;
    public GameObject doggy;
    private Vector3 offset;
    private Vector3 startPosition;
    private RectTransform dogPosition;
    private Vector2 localMousePosition;



    // Start is called before the first frame update
    void Start()
    {
        // Record Food's start position
        startPosition = transform.position;
        dogPosition = doggy.GetComponent<RectTransform>();


    }

    // Update is called once per frame
    void Update()
    {
        localMousePosition = transform.position;
        if (grab)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure there is no z-axis offset since we are working in 2D
            transform.position = mousePos + offset;
        }

        else
        {
            // return object
            transform.position = startPosition;
        }
    }

    private void OnMouseDown()
    {
        // difference between object's center and clicked point
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        grab = true;
    }

    private void OnMouseUp()
    {
        //if (dogPosition.rect.Contains(localMousePosition))
        //{
            //doggy.GetComponent<petInteractivity>().AddHungerWhenFed();
        //}
        grab = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Currently colliding with: " + other.gameObject.name);

        if (other.gameObject.name == "mouth")
        {
            if (grab)
            {
                other.GetComponentInParent<petInteractivity>().SubtractHungerWhenFed();
                grab = false;
            }
            else
            {
                //Debug.Log("Brush is over doggy but not grabbed.");
            }
        }
    }


}
