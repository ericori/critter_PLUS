using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class dailyTasks : MonoBehaviour
{
    public GameObject[] tasks;
    public Toggle[] toggles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void missionToTask(Dictionary<string, ScriptableMissions> missions)
    {
        int i = 0;
        foreach (KeyValuePair<string, ScriptableMissions> kvp in missions)
        {
            
            TextMeshProUGUI newText = tasks[i].GetComponent<TextMeshProUGUI>();
            newText.text = kvp.Value.name + " " + kvp.Value.missionProgressCounter + " of " + kvp.Value.missionCompletionTotal + " time";

            if (kvp.Value.missionCompleted == false)
            {
                toggles[i].isOn = false;
            }
            else
            {
                toggles[i].isOn = true;
            }

            //for plural forms
            if (kvp.Value.missionCompletionTotal > 1)
            {
                newText.text += "s";
            }
            i++;
        }
    }
}