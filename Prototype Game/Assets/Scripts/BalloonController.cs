using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Balloon;
    public Rigidbody2D RB;

    public int BalloonHit = 0;

    GameController GC;
    CannonController CC;

    // Use this for initializationa
    public void Start()
    {
        RB = Balloon.GetComponent<Rigidbody2D>();
        GC = FindObjectOfType<GameController>();
        CC = FindObjectOfType<CannonController>();
        VelocityChange(GC.getFloatStrength());
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log(GC.getObjectsDestroyed() + " " + GC.getObjectSpawned());
        //if (GC.getObjectsDestroyed() == GC.getObjectSpawned() && GC.getBalloonDestroyed())
        //{
        //   Debug.Log("Velocity: " + GC.getFloatStrength());
        //   VelocityChange(GC.getFloatStrength());
        //}
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