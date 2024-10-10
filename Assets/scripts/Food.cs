using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public petVars pVars;
    public missionController mission;
    
    private bool grab = false;
    public GameObject doggy;
    public GameObject kibble;
    private Vector3 offset;
    private Vector3 startPosition;
    private RectTransform dogPosition;
    private Vector2 localMousePosition;
    private Vector3 destroyPosition;



    // Start is called before the first frame update
    void Start()
    {
        // Record Food's start position
        startPosition = transform.position;
        dogPosition = doggy.GetComponent<RectTransform>();
        destroyPosition = new Vector3(15.0f, -4.52f, -1.0f);


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

        if(pVars.kibbleCount == 0){
            transform.position = destroyPosition;
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
                other.GetComponentInParent<petInteractivity>().SubtractKibbleWhenFed();

                //for mission increment
                mission.missionDistributer("Feed");

                grab = false;
            }
            else
            {
                //Debug.Log("Brush is over doggy but not grabbed.");
            }
        }
    }


}
