using System;
using TMPro;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;
        [SerializeField] private PlayerBalance _playerBalance;

        private void Update()
        {
            _balanceText.text = _playerBalance.GetBalance().ToString();
        }
    }
}