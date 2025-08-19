using UI.Settings;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    internal sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        [SerializeField] private SettingsPanel _settingsPanel;

        [SerializeField] private SceneController _sceneController;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _settingsButton.onClick.AddListener(OpenSettingsPanel);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _settingsButton.onClick.RemoveListener(OpenSettingsPanel);
            _quitButton.onClick.RemoveListener(QuitGame);
        }

        private void StartGame()
        {
            _sceneController.LoadScene("GameScene");
        }

        private void QuitGame()
        {
            _sceneController.QuitGame();
        }

        private void OpenSettingsPanel()
        {
            _settingsPanel.OpenSettings();
        }
    }
}