using System;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;
        [SerializeField] private PlayerBalance _playerBalance;

        private void Update()
        {
            _balanceText.text = _playerBalance.GetBalance().ToString();
        }
    }
}