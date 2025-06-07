using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    internal sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private float _spawnInterval;
        [SerializeField] private float _delayBetweenWaves;
        [SerializeField] private float _delayIncrease;

        [SerializeField] private int _maxEnemyCount;

        [SerializeField] private List<Transform> _waypoints;

        private float _spawnTimer;
        private int _enemyCount;
        private int _currentWave = 1;

        private bool _isWaitingForNextWave;

        private void Update()
        {
            TrySpawnEnemy();

            if (_enemyCount >= _maxEnemyCount && !_isWaitingForNextWave)
            {
                StartCoroutine(NextWave());
            }

            Debug.Log($"Current delay before next wave: {_delayBetweenWaves}");
            Debug.Log($"Current wave: {_currentWave}");
        }   

        private void TrySpawnEnemy()
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnInterval && _enemyCount < _maxEnemyCount)
            {
                Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation).GetComponent<EnemyMovement>()
                    .Init(_waypoints);

                _enemyCount++;
                _spawnTimer = 0;
            }
        }

        private void IncreaseMaxEnemyCountBeforeNextWave()
        {
            _maxEnemyCount++;
        }

        private void ResetEnemyCount()
        {
            _enemyCount = 0;
        }

        private void IncreaseDelayBetweenWaves()
        {
            _delayBetweenWaves += _delayIncrease;
        }

        private IEnumerator NextWave()
        {
            _isWaitingForNextWave = true;

            yield return new WaitForSeconds(_delayBetweenWaves);

            IncreaseMaxEnemyCountBeforeNextWave();
            ResetEnemyCount();
            IncreaseDelayBetweenWaves();

            _currentWave++;
            _isWaitingForNextWave = false;
        }
    }
}