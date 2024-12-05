using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class walktimer : MonoBehaviour
{
    public TMP_Text clockText; 
    private float elapsedTime = 0f;
    private int lastMinuteChecked = 0;
    private petVars petVarsScript;

    void Start()
    {
        petVarsScript = FindObjectOfType<petVars>();
        if (petVarsScript == null)
        {
            Debug.LogError("petVars not found.");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Convert elapsed time to hours, minutes, and seconds
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Update the timerText with formatted time
        clockText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        // Increment critterCoin every minute
        if (minutes > lastMinuteChecked)
        {
            if (petVarsScript != null)
            {
                petVarsScript.critterCoin += 10;
                Debug.Log("CritterCoin earned! Current total: " + petVarsScript.critterCoin);
            }
            lastMinuteChecked = minutes;
        }
    }
}
