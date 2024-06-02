using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMan : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private InventoryManager inventory;
    public QuestManager questManager;
    private bool canTurnIn;
    private Transform child;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        canTurnIn = false;
        child = transform.GetChild(0);

    }

    void Update()
    {
        if (canTurnIn && Input.GetKeyDown(KeyCode.E))
        {
            child.gameObject.SetActive(false);
            questManager.endQuest();
            inventory.rockNum.text = (int.Parse(inventory.woodNum.text) - 10).ToString();
            canTurnIn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        if (quest.questType == QuestManager.questTypes.Rock && int.Parse(inventory.rockNum.text) >= 10)
        {
            child.gameObject.SetActive(true);
            canTurnIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        child.gameObject.SetActive(false);
        canTurnIn = false;
    }

}
