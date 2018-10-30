﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{

    public Text gameText;

    public int rotateSpeed = 100;
    Rigidbody rigidbody;
    public float bulletSpeed;
    public static bool bulletIsCreated = false;
    private int shotsFiredCount;


    public GameObject bullet;



    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        bulletSpeed = 0.1f;

        gameText.text = "Shots Fired: " + shotsFiredCount.ToString();
        shotsFiredCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletSpeed = 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletSpeed = 0.15f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletSpeed = 0.2f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bulletSpeed = 0.25f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            bulletSpeed = 0.3f;
        }

        Vector2 position = transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletIsCreated == false)
            {
                position.x += rigidbody.transform.up.x * 1f;
                position.y += rigidbody.transform.up.y * 1f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletController>().xSpeed = rigidbody.transform.up.x * bulletSpeed;
                go.GetComponent<BulletController>().ySpeed = rigidbody.transform.up.y * bulletSpeed;
                shotsFiredCount = shotsFiredCount + 1;
                bulletIsCreated = true;
                gameText.text = "Shots Fired: " + shotsFiredCount.ToString();
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {

    }
}