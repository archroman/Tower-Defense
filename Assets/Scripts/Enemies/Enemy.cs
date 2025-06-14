using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _health;
        [SerializeField] protected int _reward;

        private PlayerBalance _playerBalance;

        [Obsolete("Obsolete")]
        private void Awake()
        {
            _playerBalance = FindObjectOfType<PlayerBalance>();
        }

        private void Die()
        {
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