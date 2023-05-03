using Aberranthian.EndlessRunner.Game.Handlers;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _moveSpeedMultiplier = 5f;

        [Header("References")]
        [SerializeField] private InputHandler _input;
        [SerializeField] private GameStateHandler _gameStateHandler;
    
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        public void Destroy()
        {
            _gameStateHandler.HandleGameOver();
            Destroy(gameObject);
        }

        private void HandleMovement()
        {
            if (_input == null) return;

            _rigidbody.velocity = new Vector2(_moveSpeedMultiplier * _input.MovementValue, 0f);
        }
    }
}