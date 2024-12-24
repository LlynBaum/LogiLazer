using UnityEngine;

namespace ProGlove
{
    public class ProGloveIk : MonoBehaviour
    {
        public Transform targetTransform;
        public Transform bone;
        
        private void LateUpdate()
        {
            var targetPosition = targetTransform.position;
            AimAt(targetPosition);
        }

        private void AimAt(Vector3 targetPosition)
        {
            var currentDirection = transform.rotation * Vector3.forward;
            var targetDirection = (targetPosition - transform.position).normalized;
            
            var aimTowards = Quaternion.FromToRotation(currentDirection, targetDirection);
            bone.rotation = aimTowards * bone.rotation;
        }
    }
}
