using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private MainTower.MainTower _mainTower;

        [Header("Animation")] [SerializeField] private float _animationDuration = 0.4f;
        [SerializeField] private float _popScale = 1.15f;

        private float _currentHealth;
        private Vector3 _baseScale;

        private void Awake()
        {
            if (!_healthText) _healthText = GetComponent<TMP_Text>();
            _baseScale = _healthText.transform.localScale;

            if (_mainTower != null)
                SetValue(_mainTower.GetTowerHealth());
            else
                SetValue(0f);
        }

        private void OnEnable()
        {
            if (_mainTower != null)
                _mainTower.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            if (_mainTower != null)
                _mainTower.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float newValue)
        {
            if (newValue <= 0f)
            {
                KillTweens();
                SetValue(0f);
                return;
            }

            AnimateTo(newValue);
        }

        private void SetValue(float value)
        {
            _currentHealth = value;
            _healthText.text = Mathf.RoundToInt(_currentHealth).ToString();
        }

        private void AnimateTo(float newValue)
        {
            float start = _currentHealth;
            float target = newValue;

            KillTweens();

            DOTween.To(() => start, v =>
                {
                    _currentHealth = v;
                    _healthText.text = Mathf.RoundToInt(_currentHealth).ToString();
                }, target, _animationDuration)
                .SetEase(Ease.OutCubic)
                .SetTarget(_healthText)
                .SetUpdate(true);

            _healthText.transform.localScale = _baseScale;
            _healthText.transform
                .DOScale(_baseScale * _popScale, _animationDuration * 0.3f)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.OutQuad)
                .SetTarget(_healthText.transform)
                .SetUpdate(true);
        }

        private void KillTweens()
        {
            DOTween.Kill(_healthText);
            DOTween.Kill(_healthText.transform);
        }
    }
}