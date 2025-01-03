using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class DeathTask : MonoBehaviour
{
    public UnityEvent onFinished = new();

    public void StartTask()
    {
        StartCoroutine(nameof(StartDeathTask));
    }
    
    protected abstract IEnumerator StartDeathTask();
}