using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    private bool canPickUp;
    private InventoryManager inventory;
    private QuestManager questManager;
    private void Awake()
    {
        canPickUp = false;
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        questManager = GameObject.FindGameObjectWithTag("QMan").GetComponent<QuestManager>();
        questManager.currentQuest.itemToCollect = "Null";
        questManager.currentQuestType = QuestManager.questTypes.Collection;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            if (questManager.currentQuestType == QuestManager.questTypes.Collection && questManager.currentQuest.itemToCollect.Equals(tag))
            {
                questManager.endQuest();
                Destroy(gameObject);
                return;
            }
            if (tag.Equals("Tree"))
            {
                if (int.Parse(inventory.axeNum.text) != 0)
                {
                    inventory.GiveItem(tag, 1);
                    Destroy(gameObject);
                }
            }else if (tag.Equals("Bippy"))
            {
                if (int.Parse(inventory.letterNum.text) < 1)
                {
                    inventory.GiveItem(tag, 1);
                }
            }
            else if (tag.Equals("Rock") || tag.Equals("Axe"))
            {
                inventory.GiveItem(this.tag, 1);
                Destroy(this.gameObject);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        if (tag.Equals("Tree"))
        {
            if (int.Parse(inventory.axeNum.text) != 0)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                canPickUp = true;
            }
        } else if (tag.Equals("Bippy") )
        {
            Debug.LogWarning("Bippy");
            if (int.Parse(inventory.letterNum.text) != 1)
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
