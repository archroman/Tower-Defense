using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    internal sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        [SerializeField] private SceneController _sceneController;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
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
    }
}