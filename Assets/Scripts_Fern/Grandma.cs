using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private InventoryManager inventory;
    private bool canPickUp;
    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        canPickUp = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            if(quest.questType == QuestManager.questTypes.Grandma)
            {
                //Start waiting (15sec?)
            }
            if (quest.questType == QuestManager.questTypes.Delivery)
            {
                inventory.letterNum.text = "0";
                quest.questIsActive = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if(quest.questType == QuestManager.questTypes.Grandma)
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
                canPickUp = true;
            }

            if (quest.questType == QuestManager.questTypes.Delivery)
            {
                if(int.Parse(inventory.letterNum.text) > 0)
                {
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    canPickUp = true;
                }
            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
        canPickUp = false;
    }

}
