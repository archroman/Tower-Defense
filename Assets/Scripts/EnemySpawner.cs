using UnityEngine;

internal sealed class EnemySpawner : MonoBehaviour
{
    private const int MaxEnemyCount = 5;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval;

    private float _spawnTimer = 0;
    private int _enemyCount = 0;

    private void Update()
    {
        TrySpawnEnemy();
    }

    private void TrySpawnEnemy()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval && _enemyCount < MaxEnemyCount)
        {
            Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
            _enemyCount++;
            _spawnTimer = 0;
        }
        else if (_enemyCount == MaxEnemyCount)
        {
            Debug.Log("Достигнуто максимальное количество врагов");
            return;
        }
    }
}