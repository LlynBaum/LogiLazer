using Parcels;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int startHealth;
    
    private int health;
    private int score;

    private void Start()
    {
        Instance = this;
        health = startHealth;
    }

    public void PlayerHit()
    {
        health--;
        Debug.Log($"Health: {health}/{startHealth}");

        if (health <= 0)
        {
            Debug.Log("Lost! Health is zero");
            Destroy(ParcelManager.Instance.gameObject);
        }
    }

    public void ParcelHit(GameObject parcel)
    {
        Destroy(parcel);
        score++;
        Debug.Log($"Score: {score}");
    }
}
