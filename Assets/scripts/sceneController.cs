using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
    public bool isBrushUnlocked;
    

    // Start is called before the first frame update
    void Start()
    {
        //petVars scpVars = FindObjectOfType<petVars>();
        //if (scpVars != null)// debug
        //{
        //    Debug.Log(" File found! Current affection: " + scpVars.affection + " Current hunger: " + scpVars.hunger);
        //}
        //else
        //{
        //    Debug.LogError("File not found in Start fxn:(");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        petVars scpVars = FindObjectOfType<petVars>();

        switch (scpVars.friendRank)
        {
            case 0:
                //Debug.Log("Friendship is 0!");
                break;
            case 1:
                //Debug.Log("Friendship is 1!");
                isBrushUnlocked = true;
                break;
            default:
                //Debug.Log("Friendship is not 1 or 0.");
                break;
        }
    }

    

}
