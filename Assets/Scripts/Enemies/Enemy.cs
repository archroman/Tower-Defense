using System;
using UnityEngine;

namespace Enemies
{
    internal sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health;

        public event Action OnDeath;

        private void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            if (_health > 0)
            {
                _health -= damage;
            }
            else if (_health <= 0)
            {
                Die();
            }
        }
    }
}