using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public KeyCode RightButton;
    public KeyCode LeftButton;
    public JumpScript JS;
    public WallInteractions WS;
    public bool countermovementenabled = true;
    public float speed;
    public Rigidbody2D rb;

    bool A;
    bool D;
 
    void FixedUpdate()
    {
        if (JS.grounded)
        {
            countermovementenabled = true;
        }

        if (Input.GetKey(RightButton) && !WS.MidWallJump && !WS.walledR)
        {
            D = true;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            D = false;
        }

        if (Input.GetKey(LeftButton) && !WS.MidWallJump && !WS.walledL)
        {
            A = true;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            A = false;
        }

        if (!A && !D && countermovementenabled)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        if (WS.MidWallJump)
        {
            if (Input.GetKey(LeftButton))
            {
                rb.AddForce(transform.right * -speed * 3);
            }

            if (Input.GetKey(RightButton))
            {
                rb.AddForce(transform.right * speed * 3);
            }
        }
        
    }


}
