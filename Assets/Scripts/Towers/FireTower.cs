using System;
using UnityEngine;

namespace Towers
{
    public class FireTower : Tower
    {
        private void Awake()
        {
            _damage += _damageBoost;
        }
    }
}