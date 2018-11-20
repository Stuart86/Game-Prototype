using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Balloon;
    public Rigidbody2D RB;

    public float FloatStrength = 0;
    public int BalloonHit = 0;

    GameController GC;
    CannonController CC;

    // Use this for initializationa
    public void Start()
    {
        RB = Balloon.GetComponent<Rigidbody2D>();
        GC = FindObjectOfType<GameController>();
        CC = FindObjectOfType<CannonController>();
    }

    // Update is called once per frame
    public void Update()
    {
        VelocityChange(1.0f);
    }

    public void VelocityChange(float FloatStrength)
    {
        RB.AddForce(Vector3.up * FloatStrength);
    }

    public void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
        GC.setBalloonDestroyed();
        //Debug.Log("Object killed yes man!");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            BalloonHit++;

            if (GC.getBalloonPenetration() == false)
            {
                Destroy(other.gameObject);
                CC.SetBulletIsCreated(false);
            }
            if (GC.getBalloonDifficulty() == BalloonHit)
            {
                Destroy(Balloon);
                CC.IncrementBalloonsDestroyedCount(1);
                CC.IncrementMoneyAmountWith(2);
            }
        }
    }
}