using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public bool questIsActive;
    public string itemToCollect; //This can be: "Rock", 

    public QuestManager.questTypes questType; // This can be : "Delivery", "Rock", "Grandma", "Tree", 
}
