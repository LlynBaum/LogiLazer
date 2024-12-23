using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    [SerializeField] private UnityEvent onPlayerHit;
    [SerializeField] private UnityEvent onParcelHit;

    private void Start()
    {
        instance = this;
    }

    public static void PlayerHit() => instance.onPlayerHit.Invoke();

    public static void ParcelHit() => instance.onParcelHit.Invoke();
}
