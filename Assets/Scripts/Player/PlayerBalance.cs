using System;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerBalance : MonoBehaviour
    {
        [SerializeField] private int _initialBalance;

        private int _balance;

        private void Awake()
        {
            _balance = _initialBalance;
        }

        public void AddBalance(int amount)
        {
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