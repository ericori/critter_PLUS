using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
 //   public static MenuSceneController instance;


    private void Update()
    {
        // PRESS KEY DOWN AND GAME TECHNICALLY RESTARTS
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Debug.Log("ESCAPE KEY WAS PRESSED");
        }
    }
    

    //Function called when hitting start game.
    public void LoadGame()
    {
        Debug.Log("loading the level...");
        SceneManager.LoadScene(1); // Refer to build order of game 
    }

    //Quits the game upon pressing button
    public void ExitGame()
    {
        Application.Quit();
    }
}
