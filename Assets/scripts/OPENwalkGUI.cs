using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPENwalkGUI : MonoBehaviour
{
    public GameObject walkGUI;

    public void OpenPanel()
    {
        if (walkGUI != null)
        {
            walkGUI.SetActive(true); 
        }
    }
}
