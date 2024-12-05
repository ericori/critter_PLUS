using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLOSEwalkGUI : MonoBehaviour
{
    public GameObject walkGUI;

    public void ClosePanel()
    {
        if (walkGUI != null)
        {
            walkGUI.SetActive(false); 
        }
        else
        {
            Debug.LogError("Popup panel is not assigned!");
        }
    }
}
