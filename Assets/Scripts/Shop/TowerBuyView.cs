using System;
using UnityEngine;
using TMPro;

namespace Shop
{
    internal sealed class TowerBuyView : MonoBehaviour
    {
        [SerializeField] private TowerBuyController _towerBuyController;
        
        [SerializeField] private TMP_Text _magicTowerCostText;
        [SerializeField] private TMP_Text _fireTowerCostText;

        private void Start()
        {
            _magicTowerCostText.text = _towerBuyController.GetMagicTowerCost().ToString();
            _fireTowerCostText.text = _towerBuyController.GetFireTowerCost().ToString();
        }
    }
}