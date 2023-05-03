using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class InputHandler : MonoBehaviour
    {
        public event Action PausePressed;
        public event Action ZoomPressed;

        public float MovementValue { get; private set; }

        private InputMap _input;
        private InputMap.PlayerActions _player;

        private void Awake()
        {
            _input = new InputMap();
            _player = _input.Player;
        }

        private void OnEnable()
        {
            _player.Pause.performed += PropogatePauseEvent;
            _player.ToggleZoom.performed += PropogateZoomEvent;

            _player.Enable();
        }

        private void OnDisable()
        {
            _player.Pause.performed -= PropogatePauseEvent;
            _player.ToggleZoom.performed -= PropogateZoomEvent;

            _player.Disable();
        }

        private void Update()
        {
            MovementValue = _player.Movement.ReadValue<float>();
        }

        public void DisablePlayerControls()
        {
            _player.Disable();
        }

        private void PropogatePauseEvent(InputAction.CallbackContext ctx)
        {
            PausePressed?.Invoke();
        }

        private void PropogateZoomEvent(InputAction.CallbackContext ctx)
        {
            ZoomPressed?.Invoke();
        }
    }
}