using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberMan : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private InventoryManager inventory;
    public QuestManager questManager;
    private bool canPickUp;
    private Transform child;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("A").GetComponent<InventoryManager>();
        canPickUp = false;
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(quest.questType == QuestManager.questTypes.Tree)
        {
            child.gameObject.SetActive(true);
        }
    }
}
