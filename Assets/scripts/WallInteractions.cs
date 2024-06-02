using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WallInteractions : MonoBehaviour
{
    public KeyCode JumpKey;
    public float wallslidespeed;
    float walleddelay;
    public Rigidbody2D rb;
    public JumpScript JS;
    public Movement MS;
    public Detectors WallDetectLeft;
    public Detectors WallDetectRight;

    public bool walledL;
    public bool walledR;

    public bool MidWallJump;
    void Start()
    {
        JumpKey = JS.JumpKey;
    }

    void LateUpdate()
    {
        if (MidWallJump)
        {
            rb.gravityScale = JS.Fallgravity;
        }
    }
    void Update()
    {
        walledR = WallDetectRight.Detected;
        walledL = WallDetectLeft.Detected;
        if (walleddelay >= 0)
        {
            walledR = false;
            walledL = false;
        }
        if (JS.grounded)
        {
            walledR = false;
            walledL = false;
            MidWallJump = false;
            walleddelay = 1;
        }
        else
        {
            walleddelay -= .1f;
        }
        if (walledR && Input.GetKeyDown(JumpKey))
        {
            MS.countermovementenabled = false;
            rb.AddForce(transform.up * JS.jumpForce*2);
            rb.AddForce(transform.right * -JS.jumpForce);
            MidWallJump = true;
        }
        if (walledL && Input.GetKeyDown(JumpKey))
        {
            MS.countermovementenabled = false;
            rb.AddForce(transform.up * JS.jumpForce*2);
            rb.AddForce(transform.right * JS.jumpForce);
            MidWallJump = true;
        }

        if (walledL || walledR)
        {
            rb.drag = 10;
        }
        else
        {
            rb.drag = 0;
        }
    }
}
