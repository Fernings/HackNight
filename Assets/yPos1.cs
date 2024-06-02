using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yPos : MonoBehaviour
{
    public GameObject player;
    public int yOffset;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + 6, transform.position.z);
    }
}
