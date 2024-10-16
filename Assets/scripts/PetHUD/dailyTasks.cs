using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dailyTasks : MonoBehaviour
{
    public missionController missions;
    public GameObject[] tasks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void missionToTask()
    {
        int i = 0;
        foreach(KeyValuePair<string, ScriptableMissions> kvp in missions.dailyMissionHashMap)
        {
            TextMeshProUGUI newText = tasks[i].GetComponent<TextMeshProUGUI>();
            newText.text = kvp.Value.name + " " + kvp.Value.missionCompletionTotal + " time";

            //for plural forms
            if(kvp.Value.missionCompletionTotal > 1 )
            {
                newText.text += "s";
            }
            i++;
        }
    }
}
