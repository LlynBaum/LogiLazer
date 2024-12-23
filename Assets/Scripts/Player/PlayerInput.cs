using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private InputAction mouseMoveAction;
        
        void Start()
        {
            mouseMoveAction = InputSystem.actions.FindAction("Look");
        }

        void Update()
        {
            
        }
    }
}
