using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float sensitivity;
        public Transform raycast;
        public float raycastLength;

        private int parcelMask;

        private void Start()
        {
            parcelMask = LayerMask.GetMask("Parcel");
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            var result = Raycast(out var hit);
            if (result)
            {
                GameManager.Instance.ParcelHit(hit.collider.gameObject);
            }
        }

        private bool Raycast(out RaycastHit hit)
        {
            Gizmos.color = Color.magenta;
            Debug.DrawRay(raycast.position, raycast.forward * 50, Color.magenta, 1f);

            var ray = new Ray(raycast.position, raycast.forward);
            return Physics.Raycast(ray: ray, hitInfo: out hit, maxDistance: raycastLength, layerMask: parcelMask);
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