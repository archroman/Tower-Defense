using UnityEngine;
using System;
using UI;

namespace MainTower
{
    internal sealed class MainTower : MonoBehaviour
    {
        [SerializeField] private float _towerHealth;

        [SerializeField] private SceneController _sceneController;

        public void TakeDamage(float amount)
        {
            _towerHealth -= amount;
            if (_towerHealth <= 0)
            {
                Time.timeScale = 0;
                _sceneController.LoadScene("RestartGameMenu");
            }
        }

        public float GetTowerHealth()
        {
            return _towerHealth;
        }
    }
}