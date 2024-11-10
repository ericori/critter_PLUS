using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MiniGame : MonoBehaviour
{
    public List<GameObject> hideMe;
    public GameObject miniRoom;
    public GameObject dogSprite;
    public GameObject fruit;
    public GameObject endHUD;
    public GameObject originalDog;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI critterCoin;

    public int score = 0;

    public int overallTimer = 30;
    public float tempTimer = 1f;

    private float spawnTime = 1f;
    private float nextSpawnTime = 0.5f;

    private Vector3 offset;

    public bool isMiniGameActive = false;
    public bool calledForReset = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (isMiniGameActive == true)
        {
            if(overallTimer == 0)
            {
                isMiniGameActive = false;
                endOfGameHUD();
            }
            else
            {
                if (Time.time - tempTimer >= 0f)
                {
                    tempTimer = Time.time + 1f;
                    overallTimer--;
                    updateTimer();
                }

                if (Time.time > spawnTime)
                {
                    spawnTime = Time.time + nextSpawnTime;
                    spawnFruit();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isMiniGameActive = false;
                    restoreBedroom();
                }

                followMouse();
            }         
        }
    }

    private void followMouse()
    {
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, dogSprite.transform.position.y, 0);
        mousePos.z = 0; // Ensure there is no z-axis offset since we are working in 2D
        dogSprite.transform.position = mousePos;
    }

    public void setUp()
    {
        calledForReset = false;
        isMiniGameActive = true;
        score = 0;
        overallTimer = 30;
        updateScore();

        //hiding gameobjects from player to set up the mini game
        foreach(GameObject var in hideMe)
        {
            var.SetActive(false);
        }

        endHUD.SetActive(false);
        miniRoom.SetActive(true);
    }

    public void restoreBedroom()
    {
        
        calledForReset = true;
        foreach(GameObject var in hideMe)
        {
            var.SetActive(true);
        }
        endHUD.SetActive(false);
        miniRoom.SetActive(false);
    }

    private void spawnFruit()
    {
        if (fruit != null)
        {
            Instantiate(fruit);
        }
        else
        {
            Debug.LogError("Heart prefab is not assigned!");
        }
    }

    public void updateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void updateTimer()
    {
        timerText.text = "Timer: " + overallTimer.ToString();
    }

    private void endOfGameHUD()
    {
        originalDog.gameObject.GetComponent<petVars>().critterCoin += score;
        critterCoin.text = score.ToString();
        endHUD.SetActive(true);
    }

}
