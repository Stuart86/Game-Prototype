﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Rigidbody2D RB;
    public GameSettings GS;
    public GameObject Balloon;
    public GameObject[] BalloonClones;
    public Transform SpawnPos;
    public Text DisplayLevelText;

    // Use this for initialization
    public void Start()
    {
        GS = FindObjectOfType<GameSettings>();
        BalloonClones = new GameObject[GS.getMaxBalloons()];
        StartCoroutine(SpawnObject(1, GS.getSpawnTime()));
        StartCoroutine(GameLevelTrigger(0));
    }
    // Update is called once per frame
    public void Update()
    {
        if (GS.getBalloonDestroyed() == true && GS.getObjectsDestroyed() == GS.getObjectSpawnedCount())
        {
            for (int i = 0; i < GS.getSpawnNumber(); i++)
            {
                StartCoroutine(SpawnObject(i, GS.getSpawnTime()));
            }

            GS.setBalloonDestroyedFalse();
        }
    }
    public IEnumerator SpawnObject(int Objectnumber, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        BalloonClones[Objectnumber] = Instantiate(Balloon, new Vector2(Random.Range(-10f, max: -2.0f), Random.Range(-4f, -3f)), Quaternion.identity);
        RB = BalloonClones[Objectnumber].GetComponent<Rigidbody2D>();

        GS.ObjectSpawnedCounter();
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
                GS.setSpawnTime(2.0f);
                GS.setSpawnNumber(1);
                GS.setFloatStrength(30.0f);
                GS.setGamelevel(2);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(30));
                break;
            case 2:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.5f);
                GS.setSpawnNumber(2);
                GS.setFloatStrength(45.0f);
                GS.setGamelevel(3);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(40));
                break;
            case 3:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.3f);
                GS.setSpawnNumber(3);
                GS.setFloatStrength(60.0f);
                GS.setGamelevel(4);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(45));
                break;
            case 4:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.1f);
                GS.setSpawnNumber(4);
                GS.setFloatStrength(75.0f);
                GS.setGamelevel(5);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(50));
                break;
            case 5:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                GS.setSpawnTime(1.0f);
                GS.setSpawnNumber(5);
                GS.setFloatStrength(95.0f);
                GS.setGamelevel(6);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(55));
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