using Parcels;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float shootCooldown;
        public float raycastLength;

        public Texture2D cursor;

        public UnityEvent onShoot;
        
        private Camera mainCamera;
        private float currentShootCooldown;
        private int parcelMask;

        private void Start()
        {
            currentShootCooldown = 0;
            mainCamera = Camera.main;
            parcelMask = LayerMask.GetMask("Parcel");

            var hotspot = new Vector2(cursor.width / 2f, cursor.height / 2f);
            Cursor.SetCursor(cursor, hotspot, CursorMode.ForceSoftware);
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

            onShoot.Invoke();
            
            if (Raycast(out var hit))
            {
                var parcel = hit.collider.GetComponent<Parcel>();
                var score = (int)parcel.parcelType;
                GameManager.Instance.ParcelHit(score);
                Destroy(hit.collider.gameObject);
            }
        }

        private bool Raycast(out RaycastHit hit)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, raycastLength, parcelMask);
        }
    }
}