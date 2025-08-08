using System;

namespace Towers
{
    internal sealed class MagicTower : Tower
    {
        private void Awake()
        {
            _damage += _damageBoost;
        }
    }
}