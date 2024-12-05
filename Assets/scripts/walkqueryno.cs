using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkqueryno : MonoBehaviour
{
    public GameObject want2walk;

    public void ClosePanel()
    {
        if (want2walk != null)
        {
            want2walk.SetActive(false); 
        }
        else
        {
            Debug.LogError("Popup panel is not assigned!");
        }
    }
}
