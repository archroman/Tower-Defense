using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    internal sealed class EnemySpawner : MonoBehaviour
    {
        private const int MaxDelayBetweenWaves = 20;

        [Header("Prefabs & Path")]
        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private List<Transform> _waypoints;

        [Header("Timing")]
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private float _delayBetweenWaves = 0f;  
        [SerializeField] private float _delayIncrease = 5f;       

        [Header("Wave")]
        [SerializeField] private int _maxEnemyCount = 1;

        [Header("Enemy Scaling")]
        [SerializeField] private float _baseHp = 60f;                
        [SerializeField] private float _hpGrowthPerWave = 1.12f;      

        [SerializeField] private float _baseReward = 10f;            
        [SerializeField] private float _rewardGrowthPerWave = 1.09f;  

        [SerializeField] private float _baseEnemyDamage = 5f;         
        [SerializeField] private float _enemyDamageStepGrowth = 1.05f;

        private float _spawnTimer;
        private float _timeBeforeNextWave;
        
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
        }

        private void TrySpawnEnemy()
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnInterval && _enemyCount < _maxEnemyCount)
            {
                int randomIndex = Random.Range(0, _enemyPrefabs.Length);

                var go = Instantiate(_enemyPrefabs[randomIndex], _spawnPoint.position, _spawnPoint.rotation);

                var movement = go.GetComponent<EnemyMovement>();
                if (movement != null)
                    movement.Init(_waypoints);

                float hp = _baseHp * Mathf.Pow(_hpGrowthPerWave, _currentWave - 1);

                int reward = Mathf.RoundToInt(_baseReward * Mathf.Pow(_rewardGrowthPerWave, _currentWave - 1));

                float damageGrowthSteps = Mathf.Floor((_currentWave - 1) / 5f);
                float damage = _baseEnemyDamage * Mathf.Pow(_enemyDamageStepGrowth, damageGrowthSteps);

                var enemy = go.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.InitStats(hp, reward, damage);
                }

                _enemyCount++;
                _spawnTimer = 0f;
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
            if (_delayBetweenWaves < MaxDelayBetweenWaves)
            {
                _delayBetweenWaves += _delayIncrease;
                if (_delayBetweenWaves > MaxDelayBetweenWaves)
                    _delayBetweenWaves = MaxDelayBetweenWaves;
            }
        }

        private IEnumerator NextWave()
        {
            _isWaitingForNextWave = true;
            _timeBeforeNextWave = _delayBetweenWaves;

            while (_timeBeforeNextWave > 0)
            {
                _timeBeforeNextWave -= Time.deltaTime;
                yield return null;
            }

            IncreaseMaxEnemyCountBeforeNextWave();
            ResetEnemyCount();
            IncreaseDelayBetweenWaves();

            _currentWave++;
            _isWaitingForNextWave = false;
        }

        public int GetCurrentWave()
        {
            return _currentWave;
        }

        public float GetTimeBeforeNextWave()
        {
            return Mathf.Max(0, _timeBeforeNextWave);
        }
    }
}
