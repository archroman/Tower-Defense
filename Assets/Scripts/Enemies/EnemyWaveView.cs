using UnityEngine;
using TMPro;

namespace Enemies
{
    internal sealed class EnemyWaveView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentWaveText;
        [SerializeField] private TMP_Text _timeBeforeNextWaveText;
        
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Update()
        {
            _currentWaveText.text = _enemySpawner.GetCurrentWave().ToString();
            
            float time = _enemySpawner.GetTimeBeforeNextWave();

            if (time > 0)
                _timeBeforeNextWaveText.text = $"Next wave: {(int)time}";
            else
                _timeBeforeNextWaveText.text = "";
        }
    }
}