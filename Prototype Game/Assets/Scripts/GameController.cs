using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Rigidbody2D RB;
    public GameSettings GS;
    public GameObject Balloon;
    public GameObject WarPigeon;
    public GameObject[] WarPigeonClones;
    public GameObject[] BalloonClones;
    public Transform SpawnPos;
    public Text DisplayLevelText;
    
    public float secondsBetweenSpawn = 2;
    public float elapsedTime = 0.0f;

    public List<int> VerticalStartingPos;


    // Use this for initialization
    public void Start()
    {
        GS = FindObjectOfType<GameSettings>();
        BalloonClones = new GameObject[GS.getMaxBalloons()];
        WarPigeonClones = new GameObject[25];
        VerticalStartingPos = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

        //GS.SetMayhemGameModeTrue();
        StartCoroutine(SpawnBalloon(1, GS.getSpawnTime()));
        StartCoroutine(GameLevelTrigger(0));
    }
    // Update is called once per frame
    public void Update()
    {
        elapsedTime += Time.deltaTime;

        if (GS.getBalloonDestroyed() == true && GS.getObjectsDestroyed() == GS.getObjectSpawnedCount())
        {
            for (int i = 0; i < GS.getSpawnNumber(); i++)
            {
                StartCoroutine(SpawnBalloon(i, GS.getSpawnTime()));
            }

            GS.setBalloonDestroyedFalse();
        }

        if (GS.GetMayhemGameMode() == true && elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            StartCoroutine(SpawnBalloon(1, GS.getSpawnTime()));
        }
    }

    public IEnumerator SpawnBalloon(int Objectnumber, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        float hor = 0;
        float ver = 0;

        if (GS.GetMayhemGameMode() == false)
        {
            hor = Random.Range(-4f, -3f);
            int idx = VerticalStartingPos[Random.Range(0, VerticalStartingPos.Count)];
            VerticalStartingPos.Remove(idx);
            ver = 5f + idx * -2.5f;
        }

        if (GS.GetMayhemGameMode() == true)
        {
            Invoke("DisableLevelText", 0);

            hor = Random.Range(-4f, -3f);
            ver = Random.Range(-8f, -2f);
        }

        Vector2 pos = new Vector2(ver, hor);

        BalloonClones[Objectnumber] = Instantiate(Balloon, pos, Quaternion.identity);
        RB = BalloonClones[Objectnumber].GetComponent<Rigidbody2D>();
        GS.ObjectSpawnedCounter();
    }


    public IEnumerator SpawnPigeon(int Objectnumber, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Vector2 pos = new Vector2(-14, 1);

        WarPigeonClones[Objectnumber] = Instantiate(WarPigeon, pos, Quaternion.identity);
        RB = WarPigeonClones[Objectnumber].GetComponent<Rigidbody2D>();
    }

    public void SpawnPigeonSetup(int MaxPigeons)
    {
        for(int i = 0; i < MaxPigeons; i++)
        {
            StartCoroutine(SpawnPigeon(i, Random.Range(5, GS.getPigeonMaxSpawnTime())));
        }
    }

    public void ReInsertBalloon(float x)
    {
        int v = (int)((x - 5f) / -2.5f);
        VerticalStartingPos.Add(v);
    }

    public void DisableLevelText()
    {
        DisplayLevelText.text = "";
    }

    public void DisplayText(int textchoice)
    {
        //Debug.Log("ObjectsDestroyed: " + ObjectsDestroyed + " ObjectsSpawned: " + ObjectSpawned);
        switch (textchoice)
        {
            case 1:
                DisplayLevelText.text = "Level " + GS.getGamelevel();
                break;
            case 2:
                DisplayLevelText.text = "You won!";
                break;
            case 3:
                DisplayLevelText.text = "Game over!";
                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            default:
                Debug.Log("Default Break");
                break;
        }

    }

    public IEnumerator GameLevelTrigger(float delayTime)
    {
        switch (GS.getGamelevel())
        {
            case 1:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.0f);
                GS.setSpawnNumber(1);
                GS.setFloatStrength(30.0f);
                GS.setGamelevel(2);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(45));
                break;
            case 2:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.5f);
                GS.setSpawnNumber(2);
                GS.setFloatStrength(45.0f);
                GS.setGamelevel(3);
                GS.setPigeonMaxSpawnTime(25);
                Invoke("DisableLevelText", 4);
                SpawnPigeonSetup(2);
                StartCoroutine(GameLevelTrigger(50));
                break;
            case 3:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.3f);
                GS.setSpawnNumber(3);
                GS.setFloatStrength(60.0f);
                GS.setGamelevel(4);
                GS.setPigeonMaxSpawnTime(15);
                Invoke("DisableLevelText", 4);
                SpawnPigeonSetup(3);
                StartCoroutine(GameLevelTrigger(60));
                break;
            case 4:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setBalloonWindRight(20);
                GS.setSpawnTime(1.1f);
                GS.setSpawnNumber(4);
                GS.setFloatStrength(75.0f);
                GS.setGamelevel(5);
                Invoke("DisableLevelText", 4);
                SpawnPigeonSetup(4);
                StartCoroutine(GameLevelTrigger(70));
                break;
            case 5:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.0f);
                GS.setSpawnNumber(5);
                GS.setFloatStrength(95.0f);
                GS.setGamelevel(6);
                GS.setPigeonMaxSpawnTime(10);
                
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(85));
                break;
            case 6:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(0.8f);
                GS.setSpawnNumber(6);
                GS.setFloatStrength(108.0f);
                Invoke("DisableLevelText", 4);
                DisplayText(2);
                break;
            default:
                Debug.Log("Default Break");
                break;
        }
    }
}