using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _health;
        [SerializeField] protected int _reward;

        [SerializeField] protected float _damage;

        [SerializeField] protected AudioSource _audioSource;
        [SerializeField] protected AudioClip _hitSound;

        private PlayerBalance _playerBalance;

        [Obsolete("Obsolete")]
        private void Awake()
        {
            _playerBalance = FindObjectOfType<PlayerBalance>();
        }

        public void InitStats(float health, int reward, float damage)
        {
            _health = health;
            _reward = reward;
            _damage = damage;
        }

        private void Die()
        {
            if (_playerBalance != null)
                _playerBalance.AddBalance(_reward);

            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            if (_audioSource != null && _audioSource.enabled && _hitSound != null)
                _audioSource.PlayOneShot(_hitSound);

            _health -= damage;

            if (_health <= 0f)
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<MainTower.MainTower>(out var tower))
            {
                tower.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}