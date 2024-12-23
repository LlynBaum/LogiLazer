using UnityEngine;

namespace ProGlove
{
    public class ProGloveIk : MonoBehaviour
    {
        public Transform targetTransform;
        public Transform rayCastTransform;
        public Transform bone;

        private void LateUpdate()
        {
            var targetPosition = targetTransform.position;
            AimAt(targetPosition);
        }

        private void AimAt(Vector3 targetPosition)
        {
            var currentDirection = rayCastTransform.forward;
            var targetDirection = targetPosition - rayCastTransform.position;
            
            var aimTowards = Quaternion.FromToRotation(currentDirection, targetDirection);
            bone.rotation = aimTowards * bone.rotation;
        }
    }
}
