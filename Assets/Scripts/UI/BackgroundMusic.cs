using UnityEngine;

namespace UI
{
    internal sealed class BackgroundMusic : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
