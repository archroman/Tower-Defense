using TMPro;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private MainTower.MainTower _mainTower;

        private void Update()
        {
            _healthText.text = _mainTower.GetTowerHealth().ToString();
        }
    }
}