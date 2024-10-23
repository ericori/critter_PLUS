using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RTCScript : MonoBehaviour
{
    public DateTime current;
    public DateTime old; //need to save and load this value...
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
        loadOldTime();
        calculateTimeAway();
    }

    private void OnDestroy()
    {
        old = current;
        PlayerPrefs.SetString("SavedDateTime", old.ToString("o"));
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        current = System.DateTime.Now;

        //midnight reset
        if(current.Hour == 24)
        {
            //reset daily missions
            //affection -100 every 24 hours
        }

        if(current.Hour - hourTracker.Hour == 1)
        {
            //feed -10
            hourTracker = current;
            Debug.Log("1 hour has passed! +10 hunger!");
        }

        if(current.Minute - minuteTracker.Minute == 1)
        {
            //critter coin increase
            minuteTracker = current;
            Debug.Log("1 minute has passed! +1 Critter Coin!");
        }
    }

    public void calculateTimeAway()
    {
        int calculatedHour = 0;
        if(current.Year == old.Year && current.Month == old.Month && current.Day == old.Day)
        {
            if(current.Hour > old.Hour)
            {
                calculatedHour = current.Hour - old.Hour;
                //hunger = hunger + calculated hour * 10
            }
        }
        else
        {
            //assign new missions
            Debug.Log("It's been way too long since you've checked in... Affection: 0, Hunger: 100");
        }
    }
    //loading old time stored in player prefs
    private void loadOldTime()
    {
        string savedDateTime = PlayerPrefs.GetString("SavedDateTime", string.Empty);

        // Convert the string back to DateTime
        if (!string.IsNullOrEmpty(savedDateTime))
        {
            old = DateTime.Parse(savedDateTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }
        else
        {
            old = current;
        }
    }

    
}
