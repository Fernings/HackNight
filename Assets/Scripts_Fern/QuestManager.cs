using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Quest currentQuest;
    public float timeLeft;
    public TextMeshProUGUI questGoal;
    public TextMeshProUGUI timer;

    private WinManager WM;

    public GameObject questSelection;
    public GameObject questTracker;
    private int numQuestsCompleted;

    private float timeBetweenQuests;
    public enum questTypes
    {
        None,
        Delivery,
        Grandma,
        Rock,
        Tree,
        Collection
    };

    public questTypes currentQuestType = questTypes.None;

    private void Start()
    {
        currentQuest.questType = questTypes.None; currentQuestType = questTypes.None;
        WM = gameObject.GetComponent<WinManager>();
        timeLeft = 120;
        numQuestsCompleted = 0;
        currentQuest.questIsActive = false;
    }

    private void Update()
    {
        
        if(timeBetweenQuests > 0)
        {
            timeBetweenQuests -= (Time.deltaTime * 1.2f );
        }
        if(timeBetweenQuests <= 0 && !currentQuest.questIsActive)
        {
            if (!questSelection.activeSelf)
            {
                questSelection.SetActive(true);
            }
        }
        if (currentQuest.questIsActive)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            WM.EndGame("Player 2 ", "Time ran out.");
        }
        timer.text = (((int)timeLeft)).ToString();
        if(numQuestsCompleted >= 7)
        {
            WM.EndGame("Player 1 ", "Player 1 Completed All Side Quests (Maybe the real main quest was the side quests we made along the way)");
        }
    }

    public void setName(string str)
    {
        currentQuest.itemToCollect = str;
    }
    public void startQuest(string questName)
    {

        switch (questName)
        {
            case "Delivery":
                currentQuestType = questTypes.Delivery;
                questGoal.text = "Deliver Little Timmy's Letter To his Grandma";
                currentQuest.itemToCollect = "Letter";
                currentQuest.questType = questTypes.Delivery;
                break;
            case "Grandma":
                currentQuestType = questTypes.Grandma; currentQuest.questType = questTypes.Grandma;
                questGoal.text = "Spend Time With Grandma";
                currentQuest.itemToCollect = null;
                
                break;
            case "Rock":
                currentQuestType = questTypes.Rock; currentQuest.questType = questTypes.Rock;
                questGoal.text = "Feed \"THE GOBBLER\" 10 Rocks";
                
                break;
            case "Tree":
                currentQuestType = questTypes.Tree; currentQuest.questType = questTypes.Tree;
                questGoal.text = "Give 5 wood to the Lumberjack";
                break;
            case "Collection":
                currentQuestType = questTypes.Collection; currentQuest.questType = questTypes.Collection;
                questGoal.text = "Collect a : " + currentQuest.itemToCollect;
                break;

            default:
                currentQuestType = questTypes.None; currentQuest.questType = questTypes.None;
                questGoal.text = "";
                return;
        }
        currentQuest.questIsActive = true;
        timeLeft += 50;
    }


    public void endQuest()
    {
        Debug.Log("Quest Ended!");
        questTracker.SetActive(false);
        timeBetweenQuests += 5;
        currentQuest.questIsActive = false;
    }
}
