using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

internal sealed class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval;

    [SerializeField] private int _maxEnemyCount;
    
    [SerializeField] private List<Transform> _waypoints;

    private float _spawnTimer;
    private int _enemyCount;

    private void Update()
    {
        TrySpawnEnemy();
    }

    private void TrySpawnEnemy()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval && _enemyCount < _maxEnemyCount)
        {
            Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation).GetComponent<EnemyMovement>().Init(_waypoints);
            _enemyCount++;
            _spawnTimer = 0;
        }
        else if (_enemyCount == _maxEnemyCount)
        {
            return;
        }
    }
}