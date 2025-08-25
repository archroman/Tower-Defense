using System;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Settings;

namespace Player
{
    internal sealed class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;
        [SerializeField] private PlayerBalance _playerBalance;

        [Header("Animation")]
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private float _popScale = 1.2f;

        private int _currentBalance;
        private Vector3 _baseScale;

        private void Awake()
        {
            if (!_balanceText) _balanceText = GetComponent<TMP_Text>();
            _baseScale = _balanceText.transform.localScale;

            SetValue(_playerBalance ? _playerBalance.GetBalance() : 0);
        }

        private void OnEnable()
        {
            if (_playerBalance != null)
                _playerBalance.BalanceChanged += OnBalanceChanged;
        }

        private void OnDisable()
        {
            if (_playerBalance != null)
                _playerBalance.BalanceChanged -= OnBalanceChanged;
        }

        private void Start()
        {
            _balanceText.text = NumberFormatter.FormatNumber(_playerBalance.GetBalance());
        }

        private void OnBalanceChanged(int newValue)
        {
            AnimateTo(newValue);
        }

        private void SetValue(int value)
        {
            _currentBalance = value;
            _balanceText.text = _currentBalance.ToString();
        }

        private void AnimateTo(int newValue)
        {
            int start = _currentBalance;
            int target = newValue;

            DOTween.Kill(_balanceText);
            DOTween.Kill(_balanceText.transform);

            DOTween.To(() => (float)start, v =>
            {
                _currentBalance = Mathf.RoundToInt(v);
                _balanceText.text = NumberFormatter.FormatNumber(_currentBalance);
            }, target, _animationDuration)
            .SetEase(Ease.OutCubic)
            .SetTarget(_balanceText);

            _balanceText.transform.localScale = _baseScale;
            _balanceText.transform
                .DOScale(_baseScale * _popScale, _animationDuration * 0.3f)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.OutQuad)
                .SetTarget(_balanceText.transform);
        }
    }
}
