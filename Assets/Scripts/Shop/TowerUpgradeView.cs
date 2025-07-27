using System;
using UnityEngine;
using TMPro;
using Towers;

namespace Shop
{
    internal sealed class TowerUpgradeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _upgradeCostText;
        [SerializeField] private TMP_Text _currentDamageText;

        private TowerUpgradeController _upgradeController;
        private Tower _tower;

        private void Update()
        {
            _upgradeCostText.text = _upgradeController.GetUpgradeCost().ToString();
            _currentDamageText.text = $"Current damage: {_tower.GetCurrentDamage():F1}";
        }

        public void SetUpgradeController(TowerUpgradeController controller)
        {
            _upgradeController = controller;
        }

        public void SetTower(Tower tower)
        {
            _tower = tower;
        }
    }
}