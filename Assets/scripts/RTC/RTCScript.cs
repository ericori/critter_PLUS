using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RTCScript : MonoBehaviour
{
    public DateTime current;
    public DateTime old;
    public DateTime hourTracker;
    public DateTime minuteTracker;

    public string currentTime;
    public string pastTime;


    // Start is called before the first frame update
    void Start()
    {
        current = System.DateTime.Now;
        hourTracker = current;
        minuteTracker = current;
    }

    // Update is called once per frame
    void Update()
    {
        current = System.DateTime.Now;
        if(current.Hour == 24)
        {
            //reset daily missions
            //affection -100 every 24 hours
        }

        if(current.Hour - hourTracker.Hour <= 1)
        {
            //feed -10
            hourTracker = current;
        }

        if(current.Minute - minuteTracker.Minute <= 0)
        {
            //critter coin increase
            minuteTracker = current;
        }
    }

    private void OnDestroy()
    {
        old = current;
        PlayerPrefs.SetString("SavedDateTime", old.ToString("o"));
        PlayerPrefs.Save(); 
    }
}
