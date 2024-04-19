using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        Invoke("GoBall", 2); 
    }
   void GoBall()
{
    float rand = Random.Range(0, 2);
    Vector2 force = Vector2.zero;

    if (rand < 1)
    { 
        force = new Vector2(50, -15); 
    }
    else
    {
        force = new Vector2(-50, -15);
    }

    force *= 10.0f;

    rb2d.AddForce(force);
}


    void ResetBall() 
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x + (coll.collider.attachedRigidbody.velocity.y / 4);
            vel.y = (rb2d.velocity.y / 3) + (coll.collider.attachedRigidbody.velocity.y / 2); 
            rb2d.velocity = vel;

        }
    }

}