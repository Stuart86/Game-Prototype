using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;

    CannonController CC;


    // Use this for initialization
    void Start()
    {
        CC = FindObjectOfType<CannonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CC.gameIsPaused)
        {
            Vector2 position = transform.position;
            position.x += xSpeed;
            position.y += ySpeed;
            transform.position = position;
        }
    }

    void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
        CC.SetBulletIsCreated(false);
    }
}