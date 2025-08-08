using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal sealed class InGameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        [SerializeField] private SceneController _sceneController;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _mainMenuButton.onClick.AddListener(OpenMainMenu);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _mainMenuButton.onClick.RemoveListener(OpenMainMenu);
        }

        private void RestartGame()
        {
            _sceneController.LoadScene("GameScene");
        }

        private void OpenMainMenu()
        {
            _sceneController.LoadScene("MainMenu");
        }
    }
}