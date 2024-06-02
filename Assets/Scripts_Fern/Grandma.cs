using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private InventoryManager inventory;
    public QuestManager questManager;
    private bool canPickUp;
    bool isGrandmaWaiting;
    private float grandmaTimer;



    private Transform child;
    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        canPickUp = false;
        grandmaTimer = 20f;
        child = transform.GetChild(0);
    }
    private void Update()
    {
        if (isGrandmaWaiting)
        {
            grandmaTimer -= Time.deltaTime;
        }
        if(grandmaTimer <= 0)
        {
            child.GetChild(0).gameObject.SetActive(false);
            child.GetChild(1).gameObject.SetActive(false);
            child.GetChild(2).gameObject.SetActive(false);
            questManager.endQuest();
            grandmaTimer = 20;
        }
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            if(quest.questType == QuestManager.questTypes.Grandma)
            {
                grandmaTimer = 20.0f;
                this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                canPickUp = false;
                isGrandmaWaiting = true;
            }
            if (quest.questType == QuestManager.questTypes.Delivery)
            {
                canPickUp = false;
                inventory.letterNum.text = "0";
                quest.questIsActive = false;
                questManager.endQuest();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(quest.questType == QuestManager.questTypes.Grandma)
            {
                child.GetChild(1).gameObject.SetActive(true);
                canPickUp = true;
            }

            if (quest.questType == QuestManager.questTypes.Delivery)
            {
                if(int.Parse(inventory.letterNum.text) > 0)
                {
                    child.GetChild(0).gameObject.SetActive(true);
                    canPickUp = true;
                }
            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        child.GetChild(0).gameObject.SetActive(false);
        child.GetChild(1).gameObject.SetActive(false);
        canPickUp = false;
        isGrandmaWaiting = false;
    }

}
