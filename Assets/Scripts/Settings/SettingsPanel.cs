using UI;
using UnityEngine;

namespace Settings
{
    internal sealed class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        
        [SerializeField] private InputHandler _inputHandler;

        private void Awake()
        {
            _settingsPanel.SetActive(false);
        }

        private void OnEnable()
        {
            _inputHandler.EscapePressed += CloseSettings;
        }

        private void OnDisable()
        {
            _inputHandler.EscapePressed -= CloseSettings;
        }

        public void OpenSettings()
        {
            _settingsPanel.SetActive(true);
        }

        public void CloseSettings()
        {
            _settingsPanel.SetActive(false);
        }
    }
}