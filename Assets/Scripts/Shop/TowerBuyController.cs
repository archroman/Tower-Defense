using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class TowerBuyController : MonoBehaviour
    {
        [SerializeField] private GameObject _towerShopPanel;

        [SerializeField] private Button _buyFireTowerButton;
        [SerializeField] private Button _buyMagicTowerButton;

        [SerializeField] private GameObject _fireTower;
        [SerializeField] private GameObject _magicTower;

        [SerializeField] private int _fireTowerCost;
        [SerializeField] private int _magicTowerCost;

        [SerializeField] private PlayerBalance _playerBalance;

        private void OnEnable()
        {
            _buyFireTowerButton.onClick.AddListener(BuyFireTower);
            _buyMagicTowerButton.onClick.AddListener(BuyMagicTower);
        }

        private void OnDisable()
        {
            _buyFireTowerButton.onClick.RemoveListener(BuyFireTower);
            _buyMagicTowerButton.onClick.RemoveListener(BuyMagicTower);
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
            Destroy(gameObject);
        }

        private void BuyMagicTower()
        {
            _playerBalance.RemoveBalance(_magicTowerCost);
            _magicTower.gameObject.SetActive(true);
            _towerShopPanel.SetActive(false);
            Destroy(gameObject);
        }

        private void CheckPlayerBalance()
        {
            _buyFireTowerButton.interactable = _playerBalance.GetBalance() >= _fireTowerCost;
            _buyMagicTowerButton.interactable = _playerBalance.GetBalance() >= _magicTowerCost;
        }
    }
}