using System;
using UnityEngine;

namespace Towers
{
    internal sealed class FireTower : Tower
    {
        private void Awake()
        {
            ConfigureDamage(baseDamage: 12f, damagePerLevel: 6f, startLevel: 0);
            ConfigureUpgradeCost(baseCost: 80f, multiplier: 1.25f);
        }
    }
}