using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    private bool canPickUp;
    private InventoryManager inventory;
    private void Awake()
    {
        canPickUp = false;
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            if (this.tag.Equals("Tree"))
            {
                if (int.Parse(inventory.axeNum.text) != 0)
                {
                    inventory.GiveItem(this.tag, 1);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                inventory.GiveItem(this.tag, 1);
                Destroy(this.gameObject);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag.Equals("Tree"))
        {
            if (int.Parse(inventory.axeNum.text) != 0)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                canPickUp = true;
            }
        }
        else {
            this.transform.GetChild(0).gameObject.SetActive(true);
            canPickUp = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        canPickUp = false;
    }
}
