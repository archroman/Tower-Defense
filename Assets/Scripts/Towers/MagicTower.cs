using System;

namespace Towers
{
    internal sealed class MagicTower : Tower
    {
        private void Awake()
        {
            ConfigureDamage(baseDamage: 20f, damagePerLevel: 10f, startLevel: 0);
            ConfigureUpgradeCost(baseCost: 110f, multiplier: 1.25f);
        }
    }
}