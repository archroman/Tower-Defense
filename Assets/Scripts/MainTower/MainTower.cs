using UnityEngine;

namespace MainTower
{
    internal sealed class MainTower : MonoBehaviour
    {
        [SerializeField] private float _towerHealth;

        public void TakeDamage(float amount)
        {
            _towerHealth -= amount;
            if (_towerHealth <= 0)
            {
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }

        public float GetTowerHealth()
        {
            return _towerHealth;
        }
    }
}