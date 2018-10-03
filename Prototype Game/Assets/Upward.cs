using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upward : MonoBehaviour
{
    public float floatStrength = 3.5f;
    public Rigidbody2D rb;
    public GameObject Ballon;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.up * floatStrength);
    }
 
    void OnBecameInvisible()
    {

        Instantiate(Ballon, new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)), Quaternion.identity);
        Destroy(Ballon);
    }

}
