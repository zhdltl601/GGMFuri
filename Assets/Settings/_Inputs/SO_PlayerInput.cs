using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    [CreateAssetMenu(menuName = "SO/PlayerInput")]
    public class SO_PlayerInput : ScriptableObject,
        Controls.IPlayerActions
    {
        public Vector2 Movement { get; private set; }
        public Vector2 MousePosition { get; private set; }

        private Controls _controls;
        private void Awake()
        {
            Debug.Log("awa");
        }
        private void OnEnable()
        {
            Debug.Log("en");
            if (_controls == null)
            {
                _controls = new();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }
        private void OnDisable()
        {
            Debug.Log("di");
            _controls.Player.Disable();
        }
        private void OnDestroy()
        {
            Debug.Log("des"); 
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            Vector2 value     = context.ReadValue<Vector2>();
Vector2 converted = value;
            MousePosition = converted;
        }
    }
}
