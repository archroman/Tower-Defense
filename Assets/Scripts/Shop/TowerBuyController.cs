using Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class TowerBuyController : MonoBehaviour
    {
        [SerializeField] private GameObject _towerShopPanel;

        [SerializeField] private Button _buyFireTowerButton;
        [SerializeField] private Button _buyMagicTowerButton;

        [SerializeField] private Button _closeShopPanel;

        [SerializeField] private GameObject _fireTower;
        [SerializeField] private GameObject _magicTower;

        [SerializeField] private int _fireTowerCost;
        [SerializeField] private int _magicTowerCost;

        [SerializeField] private TowerUpgradeController _fireTowerUpgradeController;
        [SerializeField] private TowerUpgradeController _magicTowerUpgradeController;

        [SerializeField] private PlayerBalance _playerBalance;
        
        [SerializeField] private InputHandler _inputHandler;

        private void OnEnable()
        {
            _buyFireTowerButton.onClick.AddListener(BuyFireTower);
            _buyMagicTowerButton.onClick.AddListener(BuyMagicTower);
            _closeShopPanel.onClick.AddListener(CloseBuyTowerPanel);
            _inputHandler.EscapePressed += CloseBuyTowerPanel;
        }

        private void OnDisable()
        {
            _buyFireTowerButton.onClick.RemoveListener(BuyFireTower);
            _buyMagicTowerButton.onClick.RemoveListener(BuyMagicTower);
            _closeShopPanel.onClick.RemoveListener(CloseBuyTowerPanel);
            _inputHandler.EscapePressed -= CloseBuyTowerPanel;
        }

        private void Awake()
        {
            _towerShopPanel.SetActive(false);
            _fireTower.gameObject.SetActive(false);
            _magicTower.gameObject.SetActive(false);
        }

        private void Update()
        {
            CheckPlayerBalance();
        }

        private void OnMouseUpAsButton()
        {
            _towerShopPanel.SetActive(true);
        }

        private void BuyFireTower()
        {
            _playerBalance.RemoveBalance(_fireTowerCost);
            _fireTower.gameObject.SetActive(true);
            _towerShopPanel.SetActive(false);
            gameObject.SetActive(false);
            _fireTowerUpgradeController.ActivateButton();
        }

        private void BuyMagicTower()
        {
            _playerBalance.RemoveBalance(_magicTowerCost);
            _magicTower.gameObject.SetActive(true);
            _towerShopPanel.SetActive(false);
            gameObject.SetActive(false);
            _magicTowerUpgradeController.ActivateButton();
        }

        private void CheckPlayerBalance()
        {
            _buyFireTowerButton.interactable = _playerBalance.GetBalance() >= _fireTowerCost;
            _buyMagicTowerButton.interactable = _playerBalance.GetBalance() >= _magicTowerCost;
        }

        private void CloseBuyTowerPanel()
        {
            _towerShopPanel.SetActive(false);
        }

        public int GetFireTowerCost()
        {
            return _fireTowerCost;
        }

        public int GetMagicTowerCost()
        {
            return _magicTowerCost;
        }
    }
}