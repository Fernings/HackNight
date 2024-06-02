using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(false);
    }

    public void GiveItem(string itemName, int amount)
    {
        
    }

    public void RemoveItem(string itemName, int amount)
    {
        
    }

    public void HasItem(string itemName)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryUI.activeSelf == true)
            {
                InventoryUI.SetActive(false);
            }
            else if (InventoryUI.activeSelf == false)
            {
                InventoryUI.SetActive(true);
            }
            
        }
    }
}