using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Misc
{
    public class EnemyDestroyer : MonoBehaviour
    {
        private const string ENEMY_TAG = "Enemy";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(ENEMY_TAG))
                Destroy(collision.gameObject);
        }
    }
}