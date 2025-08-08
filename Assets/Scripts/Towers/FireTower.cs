using System;
using UnityEngine;

namespace Towers
{
    internal sealed class FireTower : Tower
    {
        private void Awake()
        {
            _damage += _damageBoost;
        }
    }
}