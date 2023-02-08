using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D body;
    public Transform ballTransform;
    Vector2 targetPosition;
    public bool isCheating = true;
    public float moveSpeed;
    public Vector2 velocity;

    private void Start()
    {
        targetPosition.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       if (isCheating)
        {
            targetPosition.y = ballTransform.position.y;

            body.MovePosition(targetPosition);
        }
       else
        {
            velocity.y = (ballTransform.position - transform.position).y;
            velocity.Normalize();
            body.velocity = velocity * moveSpeed;
        }
    }
}
