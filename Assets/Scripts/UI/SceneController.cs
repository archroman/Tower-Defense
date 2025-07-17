using UnityEngine.SceneManagement;
using UnityEngine;

namespace UI
{
    internal sealed class SceneController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}