using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    private bool canPickUp;
    private GameObject inventoryObject;
    private InventoryManager inventory;
    private void Awake()
    {
        canPickUp = false;
        inventoryObject = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObject.GetComponent<InventoryManager>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            Debug.Log(inventory.gameObject.name);
            if (this.name.Equals("Tree"))
            {
                if (int.Parse(inventory.axeNum.text) != 0)
                {
                    inventory.GiveItem(this.name, 1);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                inventory.GiveItem(this.name, 1);
                Destroy(this.gameObject);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        canPickUp = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        canPickUp = false;
    }
}
