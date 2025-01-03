using System.Collections;
using Parcels;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : DeathTask
    {
        public float sensitivity;
        public float shootCooldown;
        public Transform raycast;
        public float raycastLength;

        private float currentShootCooldown;

        private Camera mainCamera;

        private int parcelMask;
        
        bool aimingEnabled = true;

        private void Start()
        {
            currentShootCooldown = 0;
            mainCamera = Camera.main;
            parcelMask = LayerMask.GetMask("Parcel");

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (currentShootCooldown > 0f) currentShootCooldown -= Time.deltaTime;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (currentShootCooldown > 0f)
            {
                return;
            }
            currentShootCooldown = shootCooldown;

            if (Raycast(out var hit))
            {
                var parcel = hit.collider.GetComponent<Parcel>();
                var score = (int)parcel.parcelType;
                GameManager.Instance.ParcelHit(score);
                Destroy(hit.collider.gameObject);
            }
        }

        protected override IEnumerator StartDeathTask()
        {
            aimingEnabled = false;
            onFinished.Invoke();
            yield return null;
        }

        private bool Raycast(out RaycastHit hit)
        {
            var ray = new Ray(raycast.position, raycast.forward);
            return Physics.Raycast(ray, out hit, raycastLength, parcelMask);
        }

        public void OnMouseMovement(InputAction.CallbackContext context)
        {
            if (!aimingEnabled)
            {
                return;
            }
            
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