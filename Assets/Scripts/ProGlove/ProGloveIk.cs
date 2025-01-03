using UnityEngine;

namespace ProGlove
{
    public class ProGloveIk : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform bone;
        
        private void LateUpdate()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                AimAt(hit.point);
            }
            else
            {
                var targetPosition = ray.origin + ray.direction * 50f;
                AimAt(targetPosition);
            }
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
