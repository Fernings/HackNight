using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberMan : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private InventoryManager inventory;
    public QuestManager questManager;
    private bool canTurnIn;
    private Transform child;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        canTurnIn = false;
        child = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        if(canTurnIn && Input.GetKeyDown(KeyCode.E))
        {
            child.gameObject.SetActive(false);
            questManager.endQuest();
            inventory.woodNum.text = (int.Parse(inventory.woodNum.text) - 5).ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        if (quest.questType == QuestManager.questTypes.Tree && int.Parse(inventory.woodNum.text) >= 5)
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
