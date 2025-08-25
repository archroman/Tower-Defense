using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    internal sealed class PlayerBalance : MonoBehaviour
    {
        [SerializeField] private int _initialBalance;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _addCoinsSound;
        
        public event UnityAction<int> BalanceChanged;
        
        private int _balance;

        private void Awake()
        {
            _balance = _initialBalance;
        }

        public void AddBalance(int amount)
        {
            if (amount == 0) return;
            _balance += amount;
            if (_addCoinsSound && _audioSource) _audioSource.PlayOneShot(_addCoinsSound);
            BalanceChanged?.Invoke(_balance);
        }

        public bool RemoveBalance(int amount)
        {
            if (amount <= 0 || _balance < amount) return false;
            _balance -= amount;
            BalanceChanged?.Invoke(_balance);
            return true;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}