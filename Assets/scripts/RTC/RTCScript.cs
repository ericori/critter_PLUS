using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RTCScript : MonoBehaviour
{
    public DateTime current;
    public DateTime old; //need to save and load this value...
    public DateTime hourTracker;
    public DateTime minuteTracker;

    public string currentTime;
    public string pastTime;

    bool newDay;

    public petVars pet;
    public missionController missions;

    public TextMeshProUGUI affectionText;
    public TextMeshProUGUI critterCoinText;
    public TextMeshProUGUI hungerText;

    // Start is called before the first frame update
    void Start()
    {
        current = System.DateTime.Now;
        hourTracker = current;
        minuteTracker = current;
        newDay = false;
        loadOldTime();
        calculateTimeAway();
    }

    private void OnDestroy()
    {
        //saving new old time
        old = current;
        PlayerPrefs.SetString("SavedDateTime", old.ToString("o"));
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("SavedDateTime").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        current = System.DateTime.Now;

        //resetting @ midnight
        if(newDay == false)
        {
            if(current.Hour == 7)
            {
                Debug.Log("WAT");
                //reset daily missions
                missions.resetProgress();
                missions.assignDailyMissions();

                //affection -100 @ midnight
                pet.affection = 0;
                newDay = true;
            }
        }

        if(newDay == true)
        {
            if(current.Hour != 7)
            {
                newDay = false;
            }
        }

        if (current.Hour - hourTracker.Hour != 0)
        {
            //feed -10
            hourTracker = current;
            decreaseHungerbyTime(1);
            Debug.Log("1 hour has passed! +10 hunger!");
        }

        if(current.Minute - minuteTracker.Minute != 0)
        {
            //critter coin increase
            minuteTracker = current;
            pet.critterCoin++;
            updatePetHUD(critterCoinText, pet.critterCoin.ToString());
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
                decreaseHungerbyTime(calculatedHour);
                
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
            Debug.Log("Loaded DateTime: " + old);
        }
        else
        {
            old = current;
        }
    }

    public void decreaseHungerbyTime(int numHours)
    {
        pet.hunger = pet.hunger - numHours * 10;
        if(pet.hunger < 0)
        {
            pet.hunger = 0;
        }
    }

    public void updatePetHUD(TextMeshProUGUI text, string newText)
    {
        text.text = newText;
    }
}
