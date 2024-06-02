using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoomberHit : MonoBehaviour
{
    public goomber mainscript;
    public string type;
    public float knockback = 100;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (type == "head")
            {
                mainscript.Kill();
            }

            if (type == "right" || type == "left")
            {
                //damage player
                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();

                if (type == "left")
                {
                    playerRB.AddForce(Vector2.left * knockback);
                }
                else if (type == "right")
                {
                    playerRB.AddForce(Vector2.right * knockback);
                }
            }
        }

        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("sussy touched floor");
            if (type == "right")
            {
                mainscript.Turn("left");
            }

            if (type == "left")
            {
                mainscript.Turn("right");
            }
        }



    }
}