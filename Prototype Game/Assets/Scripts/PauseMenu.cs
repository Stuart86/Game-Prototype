using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{


    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject rapidfireUpgradeButton;

    public int rapidfireUpgrades;
    public int rapidfireUpgradeCost;

    public Text rapidfireCostText;
    public Text rapidfireText;

    CannonController cannonController;

    private void Start()
    {
        rapidfireUpgradeCost = 20;
        rapidfireCostText.text = "Unlock Splitshot for: " + rapidfireUpgradeCost;
        cannonController = FindObjectOfType<CannonController>();
        rapidfireUpgrades = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }


    void Pause()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void UpgradeRapidfire()
    {
        if (cannonController.GetMoneyAmount() >= rapidfireUpgradeCost)
        {
            cannonController.DecrementMoneyAmount(rapidfireUpgradeCost);


            if (rapidfireUpgrades > 3)
            {
                // rapidfireUpgradeButton.SetActive(false);
                rapidfireCostText.text = "Splitshot Fully Upgraded!";
                return;
            }

            rapidfireUpgrades += 1;
            rapidfireUpgradeCost += 15;
            rapidfireCostText.text = "Upgrade Splitshot for: " + rapidfireUpgradeCost;
        }
    }

    public int GetRapidfireUpgrades() {
        return rapidfireUpgrades;
    }

}
