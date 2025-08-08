using System;
using Player;
using Towers;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal sealed class TowerUpgradeController : MonoBehaviour
    {
        private const int UpgradeCostIncrease = 10;

        [SerializeField] private Tower _tower;

        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private TowerUpgradeView _upgradeView;
        
        [SerializeField] private Button _closeUpgradePanel;

        [SerializeField] private int _upgradeCost;
        [SerializeField] private float _damageBoost;

        [SerializeField] private Button _upgradeButton;

        [SerializeField] private PlayerBalance _playerBalance;
        
        [SerializeField] private InputHandler _inputHandler;
        
        
        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(UpgradeTower);
            _closeUpgradePanel.onClick.AddListener(CloseUpgradePanel);
            _inputHandler.EscapePressed += CloseUpgradePanel;
        }

        private void OnDisable()
        {
            _upgradeButton.onClick.RemoveListener(UpgradeTower);
            _closeUpgradePanel.onClick.RemoveListener(CloseUpgradePanel);
            _inputHandler.EscapePressed -= CloseUpgradePanel;
        }

        private void Awake()
        {
            _upgradePanel.SetActive(false);
        }

        private void Update()
        {
            CheckPlayerBalance();
        }

        private void OnMouseDown()
        {
            _upgradePanel.SetActive(true);
            _upgradeView.SetTower(_tower);
            _upgradeView.SetUpgradeController(this);
        }

        private void UpgradeTower()
        {
            _playerBalance.RemoveBalance(_upgradeCost);
            _tower.UpgradeTower(_damageBoost);
            _upgradePanel.SetActive(false);

            IncreaseUpgradeCost();
        }

        private void CheckPlayerBalance()
        {
            _upgradeButton.interactable = _playerBalance.GetBalance() >= _upgradeCost;
        }

        private void IncreaseUpgradeCost()
        {
            _upgradeCost += UpgradeCostIncrease;
        }

        public void ActivateButton()
        {
            gameObject.SetActive(true);
        }

        private void CloseUpgradePanel()
        {
            _upgradePanel.SetActive(false);
        }

        public int GetUpgradeCost()
        {
            return _upgradeCost;
        }
    }
}