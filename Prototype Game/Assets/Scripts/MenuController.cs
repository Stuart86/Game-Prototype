using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


    public void playLevelMode () {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void playSurvivalGame() {
        Debug.Log("Play Survival Game!");
    }
    public void quitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
