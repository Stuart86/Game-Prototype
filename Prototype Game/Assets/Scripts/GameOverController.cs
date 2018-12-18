using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public GameObject gameOverMenuUI;
    public Text gameOverText;
    public GameController gameController;
    public MenuController menuController;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();
        menuController = FindObjectOfType<MenuController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver() {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0;

        if (gameController.GetGameLost()) {
            gameOverText.text = "You Lost!";
        }
        if (gameController.GetGameWon()) {
            gameOverText.text = "You Won!";
        }
    }


    public void PlayLevelMode() {
        DestroyAllGameObjects();
        menuController.SetGameMode(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameController.StartGame();
        Time.timeScale = 1;

    }

    public void PlayMayhemMode() {
        DestroyAllGameObjects();
        menuController.SetGameMode(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameController.StartGame();
        Time.timeScale = 1;
    }

    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }

    public void QuitGame() {
        SceneManager.LoadScene(0);
        DestroyAllGameObjects();
    }
}
