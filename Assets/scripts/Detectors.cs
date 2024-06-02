using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectors : MonoBehaviour
{
    public bool OnPlayer;
    public string tagofobject;
    public string NameOfPlayer;
    public bool Detected;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == tagofobject)
        {
            Detected = true;
        }

        if (other.gameObject.name == NameOfPlayer)
        {
            OnPlayer = true;
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == tagofobject)
        {
            Detected = false;
        }

        if (other.gameObject.name == NameOfPlayer)
        {
            OnPlayer = false;
        }
    }
}
