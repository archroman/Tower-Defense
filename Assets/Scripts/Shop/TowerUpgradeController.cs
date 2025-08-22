using Player;
using Towers;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal sealed class TowerUpgradeController : MonoBehaviour
    {
        [SerializeField] private Tower _tower;

        [Header("UI")]
        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private TowerUpgradeView _upgradeView;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _closeUpgradePanel;

        [Header("Systems")]
        [SerializeField] private PlayerBalance _playerBalance;
        [SerializeField] private InputHandler _inputHandler;

        [Header("SFX")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clickSound;

        private void Awake()
        {
            if (_upgradePanel != null)
                _upgradePanel.SetActive(false);
        }

        private void OnEnable()
        {
            if (_upgradeButton != null) _upgradeButton.onClick.AddListener(UpgradeTower);
            if (_closeUpgradePanel != null) _closeUpgradePanel.onClick.AddListener(CloseUpgradePanel);
            if (_inputHandler != null) _inputHandler.EscapePressed += CloseUpgradePanel;
        }

        private void OnDisable()
        {
            if (_upgradeButton != null) _upgradeButton.onClick.RemoveListener(UpgradeTower);
            if (_closeUpgradePanel != null) _closeUpgradePanel.onClick.RemoveListener(CloseUpgradePanel);
            if (_inputHandler != null) _inputHandler.EscapePressed -= CloseUpgradePanel;
        }

        private void Update()
        {
            CheckPlayerBalance();
        }

        private void OnMouseDown()
        {
            if (_audioSource != null && _audioSource.enabled && _clickSound != null)
                _audioSource.PlayOneShot(_clickSound);

            if (_upgradePanel != null) _upgradePanel.SetActive(true);

            if (_upgradeView != null)
            {
                _upgradeView.SetTower(_tower);
                _upgradeView.SetUpgradeController(this);
            }
        }

        private void UpgradeTower()
        {
            if (_tower == null || _playerBalance == null) return;

            int cost = _tower.GetUpgradeCost();
            if (_playerBalance.GetBalance() < cost) return;

            _playerBalance.RemoveBalance(cost);
            _tower.UpgradeOneLevel();

            if (_upgradePanel != null)
                _upgradePanel.SetActive(false);
        }

        private void CheckPlayerBalance()
        {
            if (_upgradeButton == null || _tower == null || _playerBalance == null) return;

            int cost = _tower.GetUpgradeCost();
            _upgradeButton.interactable = _playerBalance.GetBalance() >= cost;
        }

        private void CloseUpgradePanel()
        {
            if (_upgradePanel != null)
                _upgradePanel.SetActive(false);
        }

        public int GetUpgradeCost()
        {
            return _tower != null ? _tower.GetUpgradeCost() : 0;
        }

        public void ActivateButton()
        {
            gameObject.SetActive(true);
        }
    }
}
