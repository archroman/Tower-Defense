using UnityEngine;
using System;

namespace MainTower
{
    internal sealed class MainTower : MonoBehaviour
    {
        [SerializeField] private float _towerHealth;

        public static event Action OnTowerDestroyed;
        
        public void TakeDamage(float amount)
        {
            _towerHealth -= amount;
            if (_towerHealth <= 0)
            {
                Time.timeScale = 0;
                OnTowerDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }

        public float GetTowerHealth()
        {
            return _towerHealth;
        }
    }
}