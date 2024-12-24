using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void PlayerHit()
    {
        Debug.Log("Player was hit by Parcel");
    }

    public void ParcelHit(GameObject parcel)
    {
        Debug.Log("Parcel was hit by Player");
        Destroy(parcel);
    }
}
