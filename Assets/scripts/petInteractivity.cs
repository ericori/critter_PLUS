using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petInteractivity : MonoBehaviour
{
    public petVars pVars;
    public GameObject heart;
    public missionController mission;

    private float affectionTimer = 0.0f;  // Timer to control affection addition rate
    public float affectionInterval = 0.2f;  // Interval in seconds at which affection is added

    //private float foodTimer = 0.0f; // Timer to control how often the dog can be fed
    //public float foodWait = 0.5f; // Wait five seconds to feed again

    private Animator _animator;
    private bool isLoved = false; //transition variable for animations
    private int brushTracker = 0;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pVars = GetComponent<petVars>();
        _animator = GetComponent<Animator>();
        _animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the timer by the time passed since last frame
        if (affectionTimer > 0)
        {
            affectionTimer -= Time.deltaTime;
        }

        /*
        if (foodTimer > 0)
        {
            foodTimer -= Time.deltaTime;
        }
        */
    }


    void OnMouseDown()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        
        isLoved = true;
        pVars.affection += 5;
        Debug.Log("Affection up. It is now:" + pVars.affection);
        Debug.Log("Playing Sound Effect Now:");

        //making sure the right mission gets incremented for progress
        mission.missionDistributer("Pet");

        audioManager.PlaySFX(audioManager.dogBark, 0, 3.0);
        SpawnHeart(clickPosition);
        _animator.SetBool(name: "isLoved", isLoved);
        Invoke("ResetIsLoved", _animator.GetCurrentAnimatorStateInfo(0).length);
        
    }

    public void AddAffectionWhileBrushing(Vector3 position)
    {
        // Check if the timer has elapsed
        if (affectionTimer <= 0)
        {
            isLoved = true;
            pVars.affection += 20;
            brushTracker += 20;
            Debug.Log("BRUSH Affection up. It is now: " + pVars.affection);
            SpawnHeart(position);

            //making sure the right mission gets incremented for progress
            mission.missionDistributer("Brush");

            _animator.SetBool(name: "isLoved", isLoved);
            Invoke("ResetIsLoved", _animator.GetCurrentAnimatorStateInfo(0).length);

            if (brushTracker % 120 == 0)
            {
                audioManager.PlaySFX(audioManager.dogBarks);
            }

            // Reset the timer
            affectionTimer = affectionInterval;
        }
    }

    public void SubtractHungerWhenFed()
    {
        /* 
        if(foodTimer <= 0 && pVars.hunger > 0)
        {
            pVars.hunger -= 20;
            Debug.Log("Dog Fed. Hunger is: " + pVars.hunger);

            foodTimer = foodWait;
        } 
        */

        if(pVars.hunger > 0)
        {
            pVars.hunger -= 20;
            Debug.Log("Dog Fed. Hunger is: " + pVars.hunger);
        }
        else
        {
            Debug.Log("Dog is not hungry");
        }
    }

    public void SubtractKibbleWhenFed()
    {
        /*
        if(foodTimer <= 0 && pVars.kibbleCount > 0){
            pVars.kibbleCount -= 1;
            Debug.Log("You have " + pVars.kibbleCount + " bowls of kibble left.");
        }
        */

        if(pVars.kibbleCount > 0)
        {
            pVars.kibbleCount -= 1;
            Debug.Log("You have " + pVars.kibbleCount + " bowls of kibble left.");
        }
        else{
            Debug.Log("You don't have any kibble!");
        }
    }

    private void ResetIsLoved()
    {
        isLoved = false;
        _animator.SetBool("isLoved", isLoved);
    }

    void SpawnHeart(Vector3 spawnPosition)
    {
        if (heart != null)
        {
            Instantiate(heart, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Heart prefab is not assigned!");
        }
    }
}
