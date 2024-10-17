using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class missionController : MonoBehaviour
{
    [SerializeField] public ScriptableMissions[] allMissions; //Scriptable Objects array filled with all missions
    private int dailyMissionsSize = 3; //can adjust as needed, as of right now, 3 missions everyday are assigned

    //to get unique values, we should use a dictionary/hashmap since it does not allow duplicates. Plus, easier and faster for lookups
    public Dictionary<string, ScriptableMissions> dailyMissionHashMap = new Dictionary<string, ScriptableMissions>();
    public dailyTasks tasks;


    void Start()
    {
        resetAllMissions(); //delete once RTC is implemented!

        assignDailyMissions();
        
        foreach(KeyValuePair<string, ScriptableMissions> kvp in dailyMissionHashMap)
        {
            Debug.Log("Mission: " + kvp.Key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assignDailyMissions()
    {
        
        //random number
        System.Random rand = new System.Random();

        //using a while loop so i can get specific of when i increment "i"
        int i = 0;
        while (i < dailyMissionsSize)
        {
            int randomIndex = rand.Next(allMissions.Length);
            if (!dailyMissionHashMap.ContainsKey(allMissions[randomIndex].name))
            {
                dailyMissionHashMap.Add(allMissions[randomIndex].missionName, allMissions[randomIndex]); //adding to map based on random index from allMissions
                dailyMissionHashMap[allMissions[randomIndex].missionName].isActive = true; //making the the mission active
                i++;
            }
        }
        changePetHUD();
    }

    //reset progress after new day (RTC)
    public void resetProgress()
    {
        //looping through our dictionary to reset values so they can be used again for the new day starting
        foreach(KeyValuePair<string, ScriptableMissions> keyValuePair in dailyMissionHashMap) 
        {
            keyValuePair.Value.missionProgressCounter = 0;
            keyValuePair.Value.missionCompleted = false;
            keyValuePair.Value.isActive = false;
        }
    }

    //adding points to the mission
    public void addCompletionPoints(ScriptableMissions scriptableMission)
    {
        if (!scriptableMission.missionCompleted)
        {
            scriptableMission.missionProgressCounter++;
            changePetHUD();

            if(scriptableMission.missionProgressCounter == scriptableMission.missionCompletionTotal)
            {
                scriptableMission.missionCompleted = true;
                Debug.Log("Completed " + scriptableMission.name + " " + scriptableMission.missionCompletionTotal + " times!");
            }
        }
    }

    public void missionDistributer(string key)
    {
        //mission
        if (inMap(key) && dailyMissionHashMap[key].isActive && !dailyMissionHashMap[key].missionCompleted)
        {
            addCompletionPoints(dailyMissionHashMap[key]);
            changePetHUD();
            Debug.Log(dailyMissionHashMap[key].name + ": " + dailyMissionHashMap[key].missionProgressCounter + " of " + dailyMissionHashMap[key].missionCompletionTotal);
        }
    }

    private bool inMap(string key)
    {
        if (dailyMissionHashMap.ContainsKey(key))
        {
            return true;
        }

        return false;
    }

    private void resetAllMissions()
    {
        for(int i = 0; i < allMissions.Length; i++)
        {
            allMissions[i].missionProgressCounter = 0;
            allMissions[i].missionCompleted = false;
            allMissions[i].isActive = false;
        }
    }

    public void changePetHUD()
    {
        tasks.missionToTask(dailyMissionHashMap);
    }
}
