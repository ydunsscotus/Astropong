using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public AudioSource audioPlayer;
    public Transform Ball;
    public Transform enemy;
    public float speed = 1f;
    private Vector2 destination;

    public void MoveToBall()
    {
        destination = new Vector2 (enemy.transform.position.x,Ball.position.y);
        transform.position = Vector2.Lerp(enemy.transform.position,destination,speed * Time.deltaTime);
    }

    void Update()
    {
        MoveToBall();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            audioPlayer.Play();
        }
    }
}