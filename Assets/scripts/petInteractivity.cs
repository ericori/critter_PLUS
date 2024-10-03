using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petInteractivity : MonoBehaviour
{
    public petVars pVars;

    // Start is called before the first frame update
    void Start()
    {
        pVars = GetComponent<petVars>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        pVars.affection += 5;
        Debug.Log("Affection up. It is now:" + pVars.affection);
    }

}
