using Aberranthian.EndlessRunner.Game.Player;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Enemies
{
    public class FallDownMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeedMultiplier = 6f;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += Time.deltaTime * _moveSpeedMultiplier * Vector3.down;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerController player))
                player.Destroy();
        }
    }
}