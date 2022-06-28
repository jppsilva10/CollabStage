using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionManager : MonoBehaviour
{
    public float scale;
    private MultiTouch mt;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mt = GetComponent<MultiTouch>();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (mt.index == -1) 
        {
            Debug.Log("auau");
            Vector2 direction = collision.GetContact(0).normal;
            rb.AddForce(direction * scale);
            Debug.Log(direction);
        }
        
    }
}
