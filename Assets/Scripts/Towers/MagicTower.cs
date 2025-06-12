using System;

namespace Towers
{
    public class MagicTower : Tower
    {
        private void Awake()
        {
            _damage += _damageBoost;
        }
    }
}