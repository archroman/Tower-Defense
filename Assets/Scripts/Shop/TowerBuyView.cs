using System;
using UnityEngine;
using TMPro;

namespace Shop
{
    internal sealed class TowerBuyView : MonoBehaviour
    {
        [SerializeField] private TowerBuyController _towerBuyController;
        
        [SerializeField] private TMP_Text _fireTowerCostText;
        [SerializeField] private TMP_Text _magicTowerCostText;


        private void Start()
        {
            _fireTowerCostText.text = _towerBuyController.GetFireTowerCost().ToString();
            _magicTowerCostText.text = _towerBuyController.GetMagicTowerCost().ToString();
        }
    }
}