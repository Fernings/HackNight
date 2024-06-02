using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private bool canPickUp;
    public InventoryManager inventory;
    private void Start()
    {
        canPickUp = false;
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
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
