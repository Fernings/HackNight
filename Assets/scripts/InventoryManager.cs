using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryUI;
    public TextMeshProUGUI rockNum;
    public TextMeshProUGUI woodNum;
    public TextMeshProUGUI letterNum;
    public TextMeshProUGUI axeNum;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(false);
    }

    public void GiveItem(string itemName, int amount)
    {
        Debug.Log(itemName);
        switch (itemName)
        {
            case "Rock":
                rockNum.text = (amount + int.Parse(rockNum.text)).ToString();
                break;
            case "Wood":
                woodNum.text = (amount + int.Parse(woodNum.text)).ToString();
                break;
            case "Letter":
                letterNum.text = (amount + int.Parse(letterNum.text)).ToString();
                break;
            case "Axe":
                axeNum.text = (amount + int.Parse(axeNum.text)).ToString();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
}