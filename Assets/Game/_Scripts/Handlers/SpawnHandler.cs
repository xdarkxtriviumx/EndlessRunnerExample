using System.Collections.Generic;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class SpawnHandler : MonoBehaviour
    {
        [Header("Configuration")]
        [Tooltip("How long to wait between spawning an enemy.")]
        [SerializeField] private float _spawnDelaySeconds = 1f;
        [Tooltip("The center position that spawning should happen at.")]
        [SerializeField] private Vector2 _spawnPosition = Vector2.zero;
        [Tooltip("The size of the 'x' area that spawns should happen within.")]
        [SerializeField] private float _spawnSizeX = 5f;
        [Tooltip("A list of prefabs for enemies to choose from each spawn cycle.")]
        [SerializeField] private List<GameObject> _enemyPrefabs = new();

        private float _spawnRadius;
        private float _elapsedTime;

        private void Awake()
        {
            _elapsedTime = 0f;
            _spawnRadius = _spawnSizeX * 0.5f;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _spawnDelaySeconds)
                SpawnEnemy();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new(1f, 0f, 0f, 0.3f);
            Gizmos.DrawCube(_spawnPosition, new(_spawnSizeX, 1f, 0f));
        }

        private void SpawnEnemy()
        {
            _elapsedTime = 0f;

            GameObject spawnPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];

            Vector3 spawnPos = new
            (
                Random.Range(_spawnPosition.x - _spawnRadius, _spawnPosition.x + _spawnRadius),
                _spawnPosition.y,
                0f
            );

            Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);
        }
    }
}