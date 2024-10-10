using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableMissions", menuName = "ScriptableObjects/ScriptableMissions")]
public class ScriptableMissions : ScriptableObject
{
    public string missionName; //name of the mission
    public string missionDescription; //description of mission
    public int missionCompletionTotal; //amount of times task needs to be completed
    public int missionProgressCounter; //keeping track of players current count in mission
    public bool missionCompleted; //keeps track if completed
    public bool isActive; //keeps track if mission is currently active for the day
    
}
