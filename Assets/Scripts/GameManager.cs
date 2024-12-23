using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }

    public void PlayerHit()
    {
        // Debug.Log("Player was hit by Parcel");
    }
}
