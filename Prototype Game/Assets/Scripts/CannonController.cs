using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public Text shotsFiredText;
    public Text balloonsDestroyedText;
    public Text moneyAmountText;
    public Text gameLevelText;
    public Text lifeAmountText;

    public int rotateSpeed = 120;
    Rigidbody myrigidbody;
    public float bulletSpeed;
    public bool cannonIsReloading = false;


    public int shotsFiredCount;
    public int balloonsDestroyedCount;
    public int moneyAmount;
    public int rapidFireBulletAmount;
    public int lifeAmount;

    public float rapidfireDelayTime;
    public float cannonReloadTime;

    public PauseMenu pauseMenu;
    public GameSettings gameSettings;
    public GameOverController gameOverController;
    public GameController gameController;

    public int bulletMode;
    public GameObject bullet;

    public Image pauseBackgroundImage;
    public Image pauseMenuImage;

    // Use this for initialization
    void Start()
    {
        lifeAmount = 3;
        lifeAmountText.text = "Lifes: " + lifeAmount;

        pauseMenu = FindObjectOfType<PauseMenu>();
        gameOverController = FindObjectOfType<GameOverController>();
        gameController = FindObjectOfType<GameController>();

        pauseBackgroundImage = GetComponent<Image>();
        pauseMenuImage = GetComponent<Image>();

        myrigidbody = GetComponent<Rigidbody>();
        bulletSpeed = 0.35f;

        rapidfireDelayTime = 0.1f;
        shotsFiredCount = 0;
        balloonsDestroyedCount = 0;
        bulletMode = 0;

        rapidFireBulletAmount = 0;

        moneyAmount = 0;
        cannonReloadTime = 2;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cannonIsReloading == false)
            {
                if (!PauseMenu.gameIsPaused)
                {
                    StartCoroutine(Fire(rapidfireDelayTime));

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I)){
            Time.timeScale = 10;
        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }


    void FixedUpdate()
    {

    }

    public IEnumerator Fire(float delay)
    {
        Vector2 position = transform.position;

        for (int i = 0; i <= pauseMenu.GetRapidfireUpgrades(); i++)
        {
            position.x += myrigidbody.transform.up.x * 2f;
            position.y += myrigidbody.transform.up.y * 2f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletController>().xSpeed = myrigidbody.transform.up.x * bulletSpeed;
            go.GetComponent<BulletController>().ySpeed = myrigidbody.transform.up.y * bulletSpeed;
            shotsFiredCount = shotsFiredCount + 1;

            Object.Destroy(go, 2f);

            StartCoroutine(ReloadCannon(cannonReloadTime));
            shotsFiredText.text = "Shots Fired: " + shotsFiredCount.ToString();
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator ReloadCannon(float delay) {
        cannonIsReloading = true;
        yield return new WaitForSeconds(delay);
        cannonIsReloading = false;
    }

    public void SetBulletIsCreated(bool bob) {
        cannonIsReloading = bob;
    }

    public void IncrementBalloonsDestroyedCount(int integer) {
        balloonsDestroyedCount += integer;
        balloonsDestroyedText.text = "Balloons Destroyed: " + balloonsDestroyedCount.ToString();
    }

    public void IncrementMoneyAmountWith(int integer) {
        moneyAmount += integer;
        moneyAmountText.text = "Money Amount: " + moneyAmount.ToString();
    }

    public int GetMoneyAmount() {
        return moneyAmount;
    }

    public void DecrementMoneyAmount(int incrementValue) {
        moneyAmount = moneyAmount - incrementValue;
    }

    public void SetGameLevelText(int INT) {
        if(INT == 0){
            gameLevelText.text = "Mayhem!";
            return;
        }
        gameLevelText.text = "Current Level: " + INT;
    }

    public void SetLifeAmountText() {
        lifeAmountText.text = "Lifes: " + lifeAmount;
    }
    public void DecrementLife() {
        lifeAmount = lifeAmount - 1;
        if (lifeAmount < 1) {
            gameController.SetGameIsLost();
            gameOverController.GameOver();
        }
        SetLifeAmountText();
    }

    public int GetLifeAmount() {
        return lifeAmount;
    }

    public void IncrementLife() {
        lifeAmount++;
    }
}