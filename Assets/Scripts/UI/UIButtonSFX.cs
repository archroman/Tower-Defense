using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    internal sealed class UIButtonSfx : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _clickSound;
        [SerializeField] private AudioClip _successSound;
        
        [SerializeField] private float _minInterval = 0.03f;

        private float _lastPlayTime;

        private void Reset()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayClick()
        {
            if (!_audioSource || !_clickSound) return;

            if (Time.unscaledTime - _lastPlayTime < _minInterval) return;
            _lastPlayTime = Time.unscaledTime;

            _audioSource.PlayOneShot(_clickSound);
        }

        public void PlaySuccessSound()
        {
            if (!_audioSource || !_successSound) return;

            if (Time.unscaledTime - _lastPlayTime < _minInterval) return;
            _lastPlayTime = Time.unscaledTime;

            _audioSource.PlayOneShot(_successSound);
        }
    }
}