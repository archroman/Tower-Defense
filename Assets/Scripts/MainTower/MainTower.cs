using UnityEngine;
using System;
using UI;
using UnityEngine.Events;

namespace MainTower
{
    internal sealed class MainTower : MonoBehaviour
    {
        [SerializeField] private float _towerHealth;

        [SerializeField] private SceneController _sceneController;

        public event UnityAction<float> HealthChanged;
        
        private bool _isDead;

        private void Awake()
        {
            HealthChanged?.Invoke(_towerHealth);
        }

        public void TakeDamage(float amount)
        {
            if (_isDead) return;
            if (amount <= 0f) return;

            _towerHealth = Mathf.Max(0f, _towerHealth - amount);
            HealthChanged?.Invoke(_towerHealth);

            if (_towerHealth <= 0f)
            {
                _isDead = true;
                Time.timeScale = 0f;
                _sceneController.LoadScene("RestartGameMenu");
            }
        }

        public float GetTowerHealth()
        {
            return _towerHealth;
        }
    }
}