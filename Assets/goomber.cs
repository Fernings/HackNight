using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goomber : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10;
    public Vector2 direction = Vector2.right;
    void Start()
    {
        direction = direction.normalized;
    }

    void Update()
    {
        Vector2 velocity = direction * speed;

        rb.velocity = velocity;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Turn(string directionstr)
    {
        if (directionstr == "left")
        {
            Debug.Log("Turn left");
            direction = Vector2.left;
        }

        if (directionstr == "right")
        {
            Debug.Log("Turn right");
            direction = Vector2.right;
        }
    }
}
