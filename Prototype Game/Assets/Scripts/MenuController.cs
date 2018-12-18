using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    static int gameMode;

    private void Start()
    {

    }
    public void playLevelMode () {
        gameMode = 1;
        SceneManager.LoadScene(1);
    }

    public void playMayhemMode() {
        gameMode = 2;
        Debug.Log(gameMode);
        SceneManager.LoadScene(1);
    }
    public void quitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }


    public int GetGameMode() {
        return gameMode;
    }

    public void SetGameMode(int mode) {
        gameMode = mode;
    }
}
