using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Balloon;
    public Rigidbody2D RB;

    public int BalloonHit = 0;

    public GameController GC;
    public GameSettings GS;
    public CannonController CC;

    bool WindisActive = false;

    // Use this for initializationa
    public void Start()
    {
        RB = Balloon.GetComponent<Rigidbody2D>();
        GC = FindObjectOfType<GameController>();
        GS = FindObjectOfType<GameSettings>();
        CC = FindObjectOfType<CannonController>();
        VelocityChange(GS.getFloatStrength());
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log("Virker ikke?");

        if (WindisActive == false && GS.getBalloonWindRight() > 0 == true)
        {
            RB.AddForce(Vector2.right * GS.getBalloonWindRight());
            this.WindisActive = true;
        }
        if (WindisActive == false && GS.getBalloonWindLeft() > 0 == true)
        {
            RB.AddForce(Vector2.left * GS.getBalloonWindLeft());
            this.WindisActive = true;
        }
    }

    public void VelocityChange(float FloatStrength)
    {
        RB.AddForce(Vector3.up * FloatStrength);
    }

    public void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
        GS.setBalloonDestroyedTrue();
        GC.ReInsertBalloon(Balloon.transform.position.x);
        CC.DecrementLife();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("CannonBall"))
        {
            BalloonHit++;

            if (GS.getBalloonPenetration() == false)
            {
                Destroy(other.gameObject);
            }
            if (GS.getBalloonDifficulty() == BalloonHit)
            {
                Destroy(Balloon);
                CC.IncrementBalloonsDestroyedCount(1);
                CC.IncrementMoneyAmountWith(2);
                CC.IncrementLife();
            }
        }
    } 
}