using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //balls variables
    public float movespeed;
    public Rigidbody2D body;
    Vector2 direction;
    public AudioSource sound;
    public GameManager gameManager;
    private void Start()
    {
        ResetPosition();
        SetDirection();
    }

    void ResetPosition()
    {
        //reset 00
        transform.position = Vector2.zero;

        //set velocity 0
        body.velocity = Vector2.zero;

    }
    void SetDirection()
    {
        direction.x = Random.Range(20, 100);
        direction.y = Random.Range(20, 100);
        direction.Normalize();
        body.velocity = direction * movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sound.Play();

        if (collision.gameObject.CompareTag("Kill"))
        {
            ResetPosition();
            SetDirection();

            gameManager.OnLifeLost();
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            gameManager.OnBlockDestroyed();

            if (gameManager.blocksremaining == 1)
            {
                GameObject lastblock = GameObject.FindGameObjectWithTag("Block");

                Vector2 direction = lastblock.transform.position = transform.position;
                direction.Normalize();

                body.velocity = direction * movespeed;

            }
        }
    }

}
