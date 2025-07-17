using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal sealed class InGameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private Button _restartButton;

        [SerializeField] private SceneController _sceneController;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            MainTower.MainTower.OnTowerDestroyed += OpenMenu;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            MainTower.MainTower.OnTowerDestroyed -= OpenMenu;
        }

        private void Awake()
        {
            _menuPanel.SetActive(false);
        }

        private void RestartGame()
        {
            _sceneController.RestartScene();
        }

        private void OpenMenu()
        {
            _menuPanel.SetActive(true);
        }
    }
}