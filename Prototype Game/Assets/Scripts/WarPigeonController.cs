using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarPigeonController : MonoBehaviour
{
    public GameObject WarPigeon;
    public Rigidbody2D RB;

    public GameController GC;
    public GameSettings GS;
    public CannonController CC;

    public float elapsedTime = 0.0f;
    public float secondsBetweenSpawn = 1;
    public float upForce = 50f;
    public float FlightSpeed = 200f;

    // Use this for initialization
    void Start ()
    {
        RB = WarPigeon.GetComponent<Rigidbody2D>();
        GS = FindObjectOfType<GameSettings>();
        GC = FindObjectOfType<GameController>();
        VelocityChange(GS.getFlightSpeed());
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            RB.AddForce(Vector2.up * upForce);
            Debug.Log("YES");
        }

    }
    public void VelocityChange(float FlightSpeed)
    {
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.right* this.FlightSpeed);
    }
    public void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(other.gameObject);
            Destroy(WarPigeon);
            //CC.IncrementMoneyAmountWith(2);
        }
    }

}
