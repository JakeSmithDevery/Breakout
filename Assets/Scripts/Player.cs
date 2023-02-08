using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movespeed;
    public Rigidbody2D body;
    float horiz;
    Vector2 velocity;
   
    // Update is called once per frame
    void Update()
    {
        // get vertical input from the player
        horiz = Input.GetAxisRaw("Horizontal");
        velocity.x = movespeed * horiz;
        body.velocity = velocity; 
    }
}
