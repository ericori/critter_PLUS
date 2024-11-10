using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
    public bool isBrushUnlocked;
    public bool isBrushSpawned; // check if brush spawned, if so stop spawning
    private bool isStar1Spawned;
    private bool isStar2Spawned;
    private bool isStar3Spawned;
    private bool isBallSpawned;
    public GameObject Brush; // call game object brush
    public GameObject Star; // call star
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        isBrushSpawned = false;
        isStar1Spawned = false;
        isStar2Spawned = false;
        isStar3Spawned = false;

        //petVars scpVars = FindObjectOfType<petVars>();
        //if (scpVars != null)// debug
        //{
        //    Debug.Log(" File found! Current affection: " + scpVars.affection + " Current hunger: " + scpVars.hunger);
        //}
        //else
        //{
        //    Debug.LogError("File not found in Start fxn:(");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        petVars scpVars = FindObjectOfType<petVars>();

        switch (scpVars.friendRank)
        {
            case 0:
                //Debug.Log("Friendship is 0!");
                break;
            case 1:
                //Debug.Log("Friendship is 1!");
                if (!isStar1Spawned)
                {
                    StarSpawn(scpVars.friendRank);
                    isStar1Spawned = true;
                }
                isBrushUnlocked = true;
                break;
            case 2:
                if (!isStar2Spawned)
                {
                    StarSpawn(scpVars.friendRank);
                    isStar2Spawned = true;
                }
                break;
            case 3:
                if (!isStar3Spawned)
                {
                    StarSpawn(scpVars.friendRank);
                    isStar3Spawned = true;
                }
                break;
            case 5:
                if(!isBallSpawned)
                {
                    Instantiate(Ball);
                    isBallSpawned = true;
                }
                break;
            default:
                //Debug.Log("Friendship is not 1 or 0.");
                break;
        }
        // Spawn brush whrn unlocked and not already spwaned.
        // prevents infinite brushes
        if (isBrushUnlocked && !isBrushSpawned)
        {
            Instantiate(Brush);
            isBrushSpawned = true;
        }
    }

    public void StarSpawn(int n)
    {
        Instantiate(Star, new Vector3(2 * (n - 1) + Star.transform.position.x, Star.transform.position.y, -1), Quaternion.identity);
    }



}
