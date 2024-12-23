using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float sensitivity;
        
        private InputAction mouseMoveAction;
        private Vector3 currentTargetVector;

        private void Start()
        {
            mouseMoveAction = InputSystem.actions.FindAction("Look");
            //mouseMoveAction.Enable();
        }

        private void Update()
        {
            var mouseMoveVector = mouseMoveAction.ReadValue<Vector2>();
            
            var newTargetPosition = transform.position;
            newTargetPosition.x += mouseMoveVector.x * sensitivity;
            newTargetPosition.y += mouseMoveVector.y * sensitivity;
            
            newTargetPosition.x = Mathf.Clamp(newTargetPosition.x, -5f, 5f);
            newTargetPosition.y = Mathf.Clamp(newTargetPosition.y, -3f, 3f);
            
            transform.position = newTargetPosition;
        }
    }
}
