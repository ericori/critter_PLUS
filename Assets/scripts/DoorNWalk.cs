using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNWalk : MonoBehaviour
{
    public GameObject want2walk;

    void OnMouseDown()
    {
        if (want2walk != null)
        {
            want2walk.SetActive(true);
             Debug.Log("door was clicked");
             
        }
    }
}