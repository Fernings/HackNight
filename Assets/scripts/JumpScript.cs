using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public KeyCode JumpKey;
    public KeyCode JumpKey2;
    public float BaseGravity;
    public float Fallgravity;
    public Rigidbody2D rb;
    public float jumpForce;
    
    public bool grounded;
    public Detectors GroundedDetector;

    float bouncetimer;
    
    void Update()
    {
        bouncetimer -= .1f;
        grounded = GroundedDetector.Detected;

        if(grounded)
        {
            rb.gravityScale = BaseGravity;
        }

        if (Input.GetKeyDown(JumpKey) && grounded)
        {
            StartJump();
        }

        if (Input.GetKeyDown(JumpKey2) && grounded)
        {
            StartJump();
        }

        if (Input.GetKeyUp(JumpKey))
        {
            EndJump();
        }

        if (Input.GetKey(JumpKey))
        {
            rb.gravityScale = BaseGravity;
        }
        else
        {
            rb.gravityScale = Fallgravity;
        }

        if (GroundedDetector.OnPlayer)
        {
            if (bouncetimer <= 0)
            {
                rb.AddForce(transform.up * jumpForce * 1.5f);
            }
            bouncetimer = 1;
        }
    }

    public void StartJump()
    {
        grounded = false;
        rb.AddForce(transform.up * jumpForce);
    }
    public void EndJump()
    {
        rb.gravityScale = Fallgravity;
    }
}
