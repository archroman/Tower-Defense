using System;
using UnityEngine;

namespace UI
{
    internal sealed class InputHandler : MonoBehaviour
    {
        public event Action EscapePressed;

        private void Update()
        {
            CheckEscapePressed();
        }

        private void CheckEscapePressed()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapePressed?.Invoke();
            }
        }
    }
}