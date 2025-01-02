using Parcels;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int startHealth;

    public UnityEvent<int> onScoreChange;
    public UnityEvent<int> onHealthChange;
    
    private int health;
    private int score;

    private void Start()
    {
        Instance = this;
        health = startHealth;
        
        onScoreChange.Invoke(score);
        onHealthChange.Invoke(health);
    }

    public void PlayerHit()
    {
        health--;
        onHealthChange.Invoke(health);

        if (health == 0)
        {
            Destroy(ParcelManager.Instance.gameObject);
            StateManager.SetScore(score);
        }
    }

    public void ParcelHit()
    {
        score++;
        onScoreChange.Invoke(score);
    }
}
