using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] Quest currentQuest;
    private float timeLeft;
    public Image questSprite;
    public TextMeshProUGUI questGoal;

    public enum questTypes
    {
        None,
        Delivery,
        Grandma,
        Rock,
        Tree
    };

    public questTypes currentQuestType = questTypes.None;

    private void Start()
    {
        questSprite.sprite = currentQuest.questIcon;
    }

    private void Update()
    {
        if (currentQuest.questIsActive)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            playerTwoWins();
        }

    }


    public void startQuest(string questName, float timeToComplete)
    {
        timeLeft = timeToComplete;
        questSprite.sprite = currentQuest.questIcon;

        switch (questName)
        {
            case "Delivery":
                currentQuestType = questTypes.Delivery;
                questGoal.text = "Deliver Little Timmy's Letter To his Grandma";
                break;
            case "Grandma":
                currentQuestType = questTypes.Grandma;
                questGoal.text = "Spend Time With Grandma";
                break;
            case "Rock":
                currentQuestType = questTypes.Rock;
                questGoal.text = "Feed \"THE GOBBLER\" 10 Rocks";
                break;
            case "Tree":
                currentQuestType = questTypes.Tree;
                questGoal.text = "Give 5 wood to the Lumberjack";
                break;
            default:
                currentQuestType = questTypes.None;
                questGoal.text = "";
                break;
        }
    }


    private void playerTwoWins()
    {

    }
}
