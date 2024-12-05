using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;



public class PlayerDataManager : MonoBehaviour
{
    
    // Call the doggy game Object becuase Unity needs an
    // Object to be called inorder to get/change variables in other scripts
    public GameObject doggy;
    public GameObject Wardrobe;
    public petVars pVars;
    public sceneController sceneController;
    private CritterNamingSystem CNS;
    private WardrobeClick wardrobeClick;

    
    
    public int affection;
    public int hunger;
    public int friendRank;
    public int kibbleCount;
    public int critterCoin;

    public void SaveGame()
    {
        pVars = doggy.GetComponent<petVars>();
        wardrobeClick = Wardrobe.GetComponent<WardrobeClick>();

        PlayerData playerData = new PlayerData();
        playerData.affection = pVars.affection;
        playerData.hunger = pVars.hunger;
        playerData.friendRank = pVars.friendRank;
        playerData.kibbleCount = pVars.kibbleCount;
        playerData.critterCoin = pVars.critterCoin;
        playerData.currentHat = wardrobeClick.currentHat;

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
    }

    public void LoadGame()
    {
        pVars = doggy.GetComponent<petVars>();
        wardrobeClick = Wardrobe.GetComponent<WardrobeClick>();
        sceneController = sceneController.GetComponent<sceneController>();
        CNS = FindObjectOfType<CritterNamingSystem>();
        
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            //Load Pet Variables from save file and load into petVars
            pVars.affection = loadedData.affection;
            pVars.hunger = loadedData.hunger;
            pVars.friendRank = loadedData.friendRank;
            pVars.kibbleCount = loadedData.kibbleCount;
            pVars.critterCoin = loadedData.critterCoin;
            wardrobeClick.currentHat = loadedData.currentHat;

            if(pVars.friendRank >= 1)
            {
                sceneController.isBrushUnlocked = true;
            }

            if(pVars.friendRank >= 4)
            {
                CNS.namingPanel.SetActive(true);
            }

            for (int i = 1; i < pVars.friendRank; i++)
            {
                sceneController.StarSpawn(i);
            }

            switch (wardrobeClick.currentHat)
            {
                case 0:
                    wardrobeClick.hatRenderer.sprite = null; // No hat
                    break;
                case 1:
                    wardrobeClick.hatRenderer.sprite = wardrobeClick.wizardHat; // Wizard hat
                    break;
                case 2:
                    wardrobeClick.hatRenderer.sprite = wardrobeClick.crown; // Crown
                    break;
            }
        }
        else
        {
            Debug.LogWarning("File not found!");
        }
    }
}
