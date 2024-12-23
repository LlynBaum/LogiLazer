using UnityEngine;

namespace ProGlove
{
    public class ProGloveIk : MonoBehaviour
    {
        public Transform targetTransform;
        public Transform rayCastTransform;
        public Transform bone;

        public int iterations = 10;
        
        private void LateUpdate()
        {
            var targetPosition = targetTransform.position;

            for (var i = 0; i < iterations; i++)
            {
                AimAt(targetPosition);
            }
        }

        private void AimAt(Vector3 targetPosition)
        {
            var currentDirection = rayCastTransform.forward;
            var targetDirection = targetPosition - rayCastTransform.position;
            
            var aimTowards = Quaternion.FromToRotation(currentDirection, targetDirection);
            var blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, 1.0f);
            bone.rotation = blendedRotation * bone.rotation;
        }
    }
}
