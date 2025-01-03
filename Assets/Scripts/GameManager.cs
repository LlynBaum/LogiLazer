using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int startHealth;

    public UnityEvent<int> onScoreChange;
    public UnityEvent<int> onHealthChange;
    
    public List<DeathTask> deathTasks;
    private int finishedDeathTasks;
    
    private int health;
    private int score;

    private void Start()
    {
        Instance = this;
        health = startHealth;
        
        onScoreChange.Invoke(score);
        onHealthChange.Invoke(health);
        
        deathTasks.ForEach(t => t.onFinished.AddListener(FinishDeath));
    }

    public void PlayerHit()
    {
        health--;
        var h = Mathf.Max(health, 0);
        onHealthChange.Invoke(h);

        if (h == 0)
        {
            deathTasks.ForEach(t => t.StartTask());
            StateManager.SetScore(score);
        }
    }

    private void FinishDeath()
    {
        finishedDeathTasks++;
        if (finishedDeathTasks >= deathTasks.Count)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void ParcelHit(int value)
    {
        score += value;
        onScoreChange.Invoke(score);
    }
}
