using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Balloon;
    public Rigidbody2D RB;
    public int  FloatStrength = 0;

    GameController GC;

    // Use this for initializationa
    public void Start ()
    {
        RB = Balloon.GetComponent<Rigidbody2D>();
        GC = FindObjectOfType<GameController>();
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
        }
    }
}
