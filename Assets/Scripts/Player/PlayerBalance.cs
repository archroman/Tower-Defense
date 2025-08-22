using System;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerBalance : MonoBehaviour
    {
        [SerializeField] private int _initialBalance;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _addCoinsSound;
        
        private int _balance;

        private void Awake()
        {
            _balance = _initialBalance;
        }

        public void AddBalance(int amount)
        {
            _audioSource.PlayOneShot(_addCoinsSound);
            _balance += amount;
        }

        public void RemoveBalance(int amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
            }
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}