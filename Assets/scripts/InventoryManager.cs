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

    public void GiveItem(itemName, amount)
    {
        
    }

    public void RemoveItem(itemName, amount)
    {
        
    }

    public void HasItem(itemName)
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