using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public Text shotsFiredText;
    public Text balloonsDestroyedText;
    public Text moneyAmountText;

    public int rotateSpeed = 120;
    Rigidbody rigidbody;
    public float bulletSpeed;
    public bool bulletIsCreated = false;

    public int shotsFiredCount;
    public int balloonsDestroyedCount;
    public int moneyAmount;

    public int bulletMode;

    public GameObject bullet;



    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        bulletSpeed = 0.35f;

        shotsFiredCount = 0;
        balloonsDestroyedCount = 0;
        bulletMode = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletMode = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletMode = 1;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletIsCreated == false && bulletMode == 0)
            {
                position.x += rigidbody.transform.up.x * 1f;
                position.y += rigidbody.transform.up.y * 1f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletController>().xSpeed = rigidbody.transform.up.x * bulletSpeed;
                go.GetComponent<BulletController>().ySpeed = rigidbody.transform.up.y * bulletSpeed;
                shotsFiredCount = shotsFiredCount + 1;
                bulletIsCreated = true;
                shotsFiredText.text = "Shots Fired: " + shotsFiredCount.ToString();
            }
            if (bulletIsCreated == false && bulletMode == 1)
            {
                position.x += rigidbody.transform.up.x + 0.25f;
                position.y += rigidbody.transform.up.y;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletController>().xSpeed = rigidbody.transform.up.x * bulletSpeed;
                go.GetComponent<BulletController>().ySpeed = rigidbody.transform.up.y * bulletSpeed;

                position.x += rigidbody.transform.up.x - 0.25f;
                position.y += rigidbody.transform.up.y;
                GameObject go1 = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go1.GetComponent<BulletController>().xSpeed = rigidbody.transform.up.x * bulletSpeed;
                go1.GetComponent<BulletController>().ySpeed = rigidbody.transform.up.y * bulletSpeed;

                shotsFiredCount = shotsFiredCount + 2;
                //bulletIsCreated = true;
                shotsFiredText.text = "Shots Fired: " + shotsFiredCount.ToString();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {

    }

    public void SetBulletIsCreated(bool bob) {
        bulletIsCreated = bob;
    }

    public void IncrementBalloonsDestroyedCount(int integer) {
        balloonsDestroyedCount += integer;
        balloonsDestroyedText.text = "Balloons Destroyed: " + balloonsDestroyedCount.ToString();
    }

    public void IncrementMoneyAmountWith(int integer) {
        moneyAmount += integer;
        moneyAmountText.text = "Money Amount: " + moneyAmount.ToString();
    }

}