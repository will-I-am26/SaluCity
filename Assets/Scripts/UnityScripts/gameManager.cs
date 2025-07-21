using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // The player's current level/quest
    public int currentLevel = 0;

    // List of all quests in the game (can be loaded from ScriptableObjects or JSON)
    public List<Quest> allQuests = new List<Quest>();

    void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Optionally, load quest data here (if from files/ScriptableObjects)
        LoadQuest(currentLevel);
    }

    public void LoadQuest(int levelIndex)
    {
        if (levelIndex < allQuests.Count)
        {
            // Activate quest UI, load questions, etc.
            Debug.Log("Loading quest: " + allQuests[levelIndex].questTitle);
            // You'd notify the UI or relevant scripts here
        }
        else
        {
            Debug.Log("All quests complete!");
            // Show end screen, credits, etc.
        }
    }

    public void CompleteCurrentQuest()
    {
        allQuests[currentLevel].isCompleted = true;
        currentLevel++;

        // Save progress if needed

        // Load next quest or show completion
        LoadQuest(currentLevel);
    }
}

[System.Serializable]
public class Quest
{
    public string questTitle;
    public List<Question> questions = new List<Question>();
    public bool isCompleted;
}

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> choices = new List<string>();
    public int correctAnswerIndex;
}
