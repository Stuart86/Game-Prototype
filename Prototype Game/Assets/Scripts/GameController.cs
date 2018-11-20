using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Rigidbody2D RB;
    public GameObject Balloon;
    public GameObject[] BalloonClones;
    public Transform SpawnPos;
    public Text DisplayLevelText;

    public int ObjectSpawned = 0;
    public int ObjectsDestroyed = 0;
    public int SpawnNumber;
    public int MaxBalloons = 40;
    public int BalloonArmor = 1;
    public int Gamelevel = 1;

    public float FloatStrength = 30f;
    public float SpawnTime = 0;

    public bool BalloonDestroyed = false;
    public bool BalloonPenetration = false;
    

    // Use this for initialization
    public void Start()
    {
        BalloonClones = new GameObject[MaxBalloons];
        StartCoroutine(SpawnObject(1, SpawnTime));
        StartCoroutine(GameLevelTrigger(0));
    }
    // Update is called once per frame
    public void Update()
    {
        if (BalloonDestroyed == true && ObjectsDestroyed == ObjectSpawned)
        {
            for (int i = 0; i < SpawnNumber; i++)
            {
                StartCoroutine(SpawnObject(i, SpawnTime));
            }

            BalloonDestroyed = false;
        }
    }
    public IEnumerator SpawnObject(int Objectnumber, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        BalloonClones[Objectnumber] = Instantiate(Balloon, new Vector2(Random.Range(-10f, max: -2.0f), Random.Range(-4f, -3f)), Quaternion.identity);
        RB = BalloonClones[Objectnumber].GetComponent<Rigidbody2D>();

        ObjectSpawnedCounter();
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
                DisplayLevelText.text = "Level " + Gamelevel;
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
    public void setGamelevel(int Gamelevel)
    {
        this.Gamelevel = Gamelevel;
    }
    public IEnumerator GameLevelTrigger(float delayTime)
    {
        switch (Gamelevel)
        {
            case 1:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(2.0f);
                setSpawnNumber(1);
                setFloatStrength(30.0f);
                setGamelevel(2);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(30));
                break;
            case 2:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(1.5f);
                setSpawnNumber(2);
                setFloatStrength(45.0f);
                setGamelevel(3);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(40));
                break;
            case 3:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(1.3f);
                setSpawnNumber(3);
                setFloatStrength(60.0f);
                setGamelevel(4);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(45));
                break;
            case 4:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(1.1f);
                setSpawnNumber(4);
                setFloatStrength(75.0f);
                setGamelevel(5);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(50));
                break;
            case 5:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(1.0f);
                setSpawnNumber(5);
                setFloatStrength(95.0f);
                setGamelevel(6);
                Invoke("DisableLevelText", 4);
                StartCoroutine(GameLevelTrigger(55));
                break;
            case 6:
                yield return new WaitForSeconds(delayTime);
                DisplayText(1);
                setSpawnTime(0.8f);
                setSpawnNumber(6);
                setFloatStrength(108.0f);
                Invoke("DisableLevelText", 4);
                DisplayText(2);
                break;
            default:
                Debug.Log("Default Break");
                break;
        }

    }
    public void setSpawnNumber(int SpawnNumber)
    {
        this.SpawnNumber = SpawnNumber;
    }
    public int getSpawnNumber()
    {
        return SpawnNumber;
    }
    public void ObjectSpawnedCounter()
    {
        ObjectSpawned++;
    }
    public int getObjectSpawned()
    {
        return ObjectSpawned;
    }
    public int getObjectsDestroyed()
    {
        return ObjectsDestroyed;
    }
    public void setBalloonDestroyed()
    {
        //Debug.Log("Objects destroyed = " + ObjectsDestroyed.ToString());
        ObjectsDestroyed++;
        this.BalloonDestroyed = true;
    }
    public bool getBalloonDestroyed()
    {
        return BalloonDestroyed;
    }
    public void setBalloonPenetration()
    {
        this.BalloonPenetration = true;
    }
    public bool getBalloonPenetration()
    {
        return BalloonPenetration;
    }
    public void setSpawnTime(float newSpawnTime)
    {
        this.SpawnTime = newSpawnTime;
    }
    public void setBalloonDifficulty(int Balloonlv)
    {
        this.BalloonArmor = Balloonlv;
    }
    public int getBalloonDifficulty()
    {
        return BalloonArmor;
    }
    public void setFloatStrength(float FloatStrength)
    {
        this.FloatStrength = FloatStrength;
    }
    public float getFloatStrength()
    {
        return this.FloatStrength;
    }



}