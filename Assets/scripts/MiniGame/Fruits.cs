using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private Vector3 pos;
    public Sprite[] allFruit;
    public MiniGame miniGame;
    private float destroyPos;
    private float min = 0.0f;
    private float max = 1.0f;
    private float randNum;
    private float fallSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        miniGame = FindAnyObjectByType<MiniGame>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = allFruit[Random.Range(0, allFruit.Length)];
        randNum = Random.Range(min, max);
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 aboveCamera = Camera.main.ViewportToWorldPoint(new Vector3(randNum, 1.1f, cameraPosition.z));
        transform.position = new Vector3(aboveCamera.x, aboveCamera.y, transform.position.z);

        destroyPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < destroyPos || miniGame.overallTimer == 0 || miniGame.calledForReset == true)
        {
            Destroy(this.gameObject);
        }

        HandleMovement();
    }
    private void HandleMovement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Currently colliding with: " + other.gameObject.name);

        if (other.gameObject.name == "mouth")
        {
            miniGame.score+=10;
            miniGame.updateScore();
            Destroy(this.gameObject);
            Debug.Log("Hit Mouth");
        }
    }
}
