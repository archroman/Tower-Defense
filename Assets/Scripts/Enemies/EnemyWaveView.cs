using System;
using UnityEngine;
using TMPro;

namespace Enemies
{
    internal sealed class EnemyWaveView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentWaveText;
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Update()
        {
            _currentWaveText.text = _enemySpawner.GetCurrentWave().ToString();
        }
    }
}