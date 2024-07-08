using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ForceMultiplier = 10f;
    public float maxSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        Invoke("BallStart", 2); 
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void BallStart()
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

        force *= ForceMultiplier;

        rb.AddForce(force);
    }

    void ResetBall() 
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("BallStart", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel = rb.velocity;
            Vector2 playerVel = coll.collider.attachedRigidbody.velocity;

            vel.x = Mathf.Lerp(vel.x, vel.x + (playerVel.x / 4), 0.5f);
            vel.y = Mathf.Lerp(vel.y, (vel.y / 3) + (playerVel.y / 2), 0.5f);

            rb.velocity = vel;
        }
    }
}
