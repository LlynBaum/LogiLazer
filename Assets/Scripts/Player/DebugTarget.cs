using System;
using UnityEngine;

namespace Player
{
    public class DebugTarget : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.05f);
        }
    }
}
