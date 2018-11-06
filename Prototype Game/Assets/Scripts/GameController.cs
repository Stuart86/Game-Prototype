using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int FloatStrength = 1;
    public Rigidbody2D rb;
    public GameObject Balloon;
    public bool ObjectDestroyed;


    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * FloatStrength);
    }

    void OnBecameInvisible()
    {
        FloatStrength = 1;
        GameObject Balloon = new GameObject("test");

        //rb = Instantiate(rb, new Vector2(Random.Range(-10f, -8f), Random.Range(-4f, -3f)), Quaternion.identity);
        //rb.name = "Balloon"; /*Midlertidlig løsning*/
        VelocityChange(FloatStrength);
        Destroy(Balloon);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Debug.Log("Hola");
            Invoke("SpawnObject", 2);

            //Balloon.GetComponent<Renderer>().enabled = false;
            Destroy(Balloon, 2.25f);
            Destroy(other.gameObject);
        }
    }
    public void VelocityChange(float Speed)
    {
        rb.velocity = new Vector3(0, Speed, 0);
    }

    public void SpawnObject()
    {
        Debug.Log("Her virker det!!");
        
        FloatStrength = 1;
        rb = Instantiate(rb, new Vector2(Random.Range(-10f, -8f), Random.Range(-4f, -3f)), Quaternion.identity);
        rb.name = "Balloon";
        VelocityChange(FloatStrength);
    }
}
