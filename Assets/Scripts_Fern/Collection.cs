using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    private bool canPickUp;
    private void Start()
    {
        canPickUp = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Pickup Rock.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        canPickUp = true;
    }
}
