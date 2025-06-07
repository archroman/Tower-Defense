using System;
using Player;
using UnityEngine;

namespace Enemies
{
    internal sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private int _reward;

        private PlayerBalance _playerBalance;

        public event Action OnDeath;

        [Obsolete("Obsolete")]
        private void Awake()
        {
            _playerBalance = FindObjectOfType<PlayerBalance>();
        }

        private void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            _playerBalance.AddBalance(_reward);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
        }
    }
}