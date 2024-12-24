using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float sensitivity;
        public Transform raycast;
        public float raycastLength;

        private Camera mainCamera;

        private int parcelMask;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            parcelMask = LayerMask.GetMask("Parcel");
            mainCamera = Camera.main;
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
            var ray = new Ray(raycast.position, raycast.forward);
            return Physics.Raycast(ray: ray, hitInfo: out hit, maxDistance: raycastLength, layerMask: parcelMask);
        }

        public void OnMouseMovement(InputAction.CallbackContext context)
        {
            var mouseMoveVector = context.ReadValue<Vector2>();

            var newTargetPosition = transform.position;
            newTargetPosition.x += mouseMoveVector.x * sensitivity;
            newTargetPosition.y += mouseMoveVector.y * sensitivity;

            var depth = Vector3.Distance(mainCamera.transform.position, transform.position);
            var bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, depth));
            var topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, depth));
            
            newTargetPosition.x = Mathf.Clamp(newTargetPosition.x, bottomLeft.x, topRight.x);
            newTargetPosition.y = Mathf.Clamp(newTargetPosition.y, bottomLeft.y, topRight.y);

            transform.position = newTargetPosition;
        }
    }
}