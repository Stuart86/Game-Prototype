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

    public Text moneyAmountText;

    public int ObjectSpawned = 0;
    public int ObjectsDestroyed = 0;
    public int SpawnNumber;
    public int MaxBalloons = 40;
    public float SpawnTime = 0;

    public bool BalloonDestroyed = false;

    // Use this for initialization
    public void Start ()
    {
        BalloonClones = new GameObject[MaxBalloons];
        setSpawnTime(2.0f);
        StartCoroutine(SpawnObject(1, SpawnTime));
        //SpawnObject(1); //Skal startes!
        setSpawnNumber(3);
    }

    // Update is called once per frame
    public void Update()
    {
        if (BalloonDestroyed == true && ObjectsDestroyed == ObjectSpawned)
        {
            //Debug.Log("ObjectsDestroyed = " + ObjectsDestroyed.ToString() + " ObjectSpawned = " +  ObjectSpawned.ToString());
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

        BalloonClones[Objectnumber] = (GameObject)Instantiate(Balloon, new Vector2(Random.Range(-10f, -5f), Random.Range(-4f, -3f)), Quaternion.identity);
        RB = BalloonClones[Objectnumber].GetComponent<Rigidbody2D>();

        ObjectSpawned++;
        
       //Debug.Log("Objects spawned = " + ObjectSpawned.ToString());
    }

    public void setSpawnNumber(int SpawnNumber)
    {
        this.SpawnNumber = SpawnNumber;
    }

    public void setBalloonState()
    {
        //Debug.Log("Objects destroyed = " + ObjectsDestroyed.ToString());
        ObjectsDestroyed++;
        this.BalloonDestroyed = true;
    }
    public void setSpawnTime(float newSpawnTime)
    {
        this.SpawnTime = newSpawnTime;
    }
}
