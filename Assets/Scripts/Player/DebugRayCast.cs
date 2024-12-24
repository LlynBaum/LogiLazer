using UnityEngine;

namespace Player
{
    public class DebugRayCast : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position,  transform.forward * 50, Color.red);
        }
    }
}
