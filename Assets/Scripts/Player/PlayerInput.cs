using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float sensitivity;
        public Transform raycast;
        public float raycastLength;
        public LayerMask layerMask;

        private int parcelMask;

        private void Start()
        {
            parcelMask = 1 << layerMask;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (Raycast(out var hit))
            {
                GameManager.Instance.ParcelHit(hit.collider.gameObject);
            }
        }

        private bool Raycast(out RaycastHit hit)
        {
            Gizmos.color = Color.magenta;
            Debug.DrawRay(raycast.position, raycast.TransformDirection(transform.forward) * 50, Color.magenta, 1f);
            
            return Physics.Raycast(
                origin: raycast.position, 
                direction: raycast.TransformDirection(raycast.forward),
                hitInfo: out hit,
                maxDistance: raycastLength, 
                layerMask: parcelMask);
        }

        public void OnMouseMovement(InputAction.CallbackContext context)
        {
            var mouseMoveVector = context.ReadValue<Vector2>();

            var newTargetPosition = transform.position;
            newTargetPosition.x += mouseMoveVector.x * sensitivity;
            newTargetPosition.y += mouseMoveVector.y * sensitivity;

            newTargetPosition.x = Mathf.Clamp(newTargetPosition.x, -5f, 5f);
            newTargetPosition.y = Mathf.Clamp(newTargetPosition.y, -5f, 5f);

            transform.position = newTargetPosition;
        }
    }
}