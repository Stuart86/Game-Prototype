using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{
    public int balloonsDestroyed;

    public GameObject Balloon;
    public Rigidbody2D RB;
    public int  FloatStrength = 0;

    GameController GC;
    CannonController cannonController;


    // Use this for initializationa
    public void Start ()
    {
        GameObject cannon = GameObject.Find("Cannon");
        cannonController = cannon.GetComponent<CannonController>();

        RB = Balloon.GetComponent<Rigidbody2D>();
        GC = FindObjectOfType<GameController>();
        //cannonController = FindObjectOfType <CannonController>();
    }

    // Update is called once per frame
    public void Update ()
    {
        VelocityChange(2);
    }

    public void VelocityChange(int FloatStrength)
    {
        RB.AddForce(Vector3.up * FloatStrength);
    }

    public void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
        GC.setBalloonState();
        //Debug.Log("Object killed yes man!");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(Balloon);
            Destroy(other.gameObject);

            cannonController.SetBulletIsCreated(false);
            cannonController.IncrementBalloonsDestroyedCount(1);
            cannonController.IncrementMoneyAmountWith(2);
        }
    }
}
