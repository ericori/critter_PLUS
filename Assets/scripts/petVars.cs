using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class petVars : MonoBehaviour
{
    public GameObject dog;

    public int affection;
    public int affectionCap; //affection requirement for increasing friendRank
    public int capMultiplier;
    private int affectionReset = 0;
    public int hunger;
    public bool full; //will be private after testing
    public int friendRank; //will be private after testing
    public int kibbleCount;
    public int critterCoin;
    public TrophySystem revealTrophy;
    public GameObject starTrophy;
    public GameObject genericTrophy;
    //public int kibbleCap = 10;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        full = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger == 0) //simple check for hunger, should move to a function later
        {
            full = true;
        }
        else
            full = false;

        //if (full == true)
        //{
        //    audioManager.PlaySFX(audioManager.full);
        //}

        if (full == true && affection >= affectionCap) //friend rank increase
        {
            friendRank++;
            affection = affectionReset; //resets affection to affectionReset (value = 0)
            affectionCap = affectionCap * capMultiplier; //increases cap by value determined in editor
            audioManager.PlaySFX(audioManager.levelUp);
        }

        if (starTrophy.activeSelf == false && friendRank >= 10)
        {
            revealTrophy.revealTrophy(starTrophy);
        }

        if (genericTrophy.activeSelf == false && critterCoin >= 500)
        {
            revealTrophy.revealTrophy(genericTrophy);
        }


    }


}