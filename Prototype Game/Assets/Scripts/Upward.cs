using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upward : MonoBehaviour
{
    public float FloatStrength;
    public Rigidbody2D rb;
    public GameObject Ballon;
    public bool ObjectDestroyed;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjectDestroyed == false)
        {
            FloatStrength = 1.0f;
            rb.AddForce(Vector3.up * FloatStrength);
        }  
    }

    void OnBecameInvisible()
    {
        Instantiate(this.Ballon, new Vector2(Random.Range(-10f, -8f), Random.Range(-4f, -3f)), Quaternion.identity);
        Destroy(Ballon);
        ObjectDestroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CanonBall"))
        {
            Rigidbody2D rocketInstance;
            FloatStrength = 10.0f;
            //Update();
            //rb.AddForce(Vector3.up * FloatStrength);
            //
            rocketInstance = Instantiate(rb, new Vector2(Random.Range(-10f, -8f), Random.Range(-4f, -3f)), Quaternion.identity);
            rocketInstance.velocity = new Vector3(0, FloatStrength, 0);
            Destroy(Ballon);
            ObjectDestroyed = true;
        }
    }

}
