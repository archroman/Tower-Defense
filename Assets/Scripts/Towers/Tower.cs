using Enemies;
using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [Header("Damage Config")]
        [SerializeField] protected float _baseDamage = 10f;       
        [SerializeField] protected float _damagePerLevel = 5f;    
        [SerializeField] protected int _level = 0;                 

        [Header("Upgrade Cost")]
        [SerializeField] protected float _upgradeBaseCost = 80f;   
        [SerializeField] protected float _upgradeCostMultiplier = 1.25f; 

        [Header("Attack")]
        [SerializeField] protected float _attackRange = 5f;
        [SerializeField] protected float _attackDelay = 1f;

        [Header("Targeting")]
        [SerializeField] protected LayerMask _enemyLayer;

        [Header("Shooting")]
        [SerializeField] protected GameObject _bulletPrefab;
        [SerializeField] protected Transform _firePoint;

        private float _lastAttackTime;

        public float CurrentDamage => _baseDamage + _damagePerLevel * _level;
        public int CurrentLevel => _level;

        public int GetUpgradeCost()
        {
            float cost = _upgradeBaseCost * Mathf.Pow(_upgradeCostMultiplier, _level);
            return Mathf.CeilToInt(cost);
        }

        public void UpgradeOneLevel()
        {
            _level = Mathf.Max(0, _level + 1);
        }

        public void ConfigureDamage(float baseDamage, float damagePerLevel, int startLevel = 0)
        {
            _baseDamage = Mathf.Max(0f, baseDamage);
            _damagePerLevel = Mathf.Max(0f, damagePerLevel);
            _level = Mathf.Max(0, startLevel);
        }

        public void ConfigureUpgradeCost(float baseCost, float multiplier)
        {
            _upgradeBaseCost = Mathf.Max(0f, baseCost);
            _upgradeCostMultiplier = Mathf.Max(1f, multiplier);
        }

        private void Update()
        {
            _lastAttackTime += Time.deltaTime;

            if (_lastAttackTime >= _attackDelay)
            {
                TryAttack();
                _lastAttackTime = 0f;
            }
        }

        private void TryAttack()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].TryGetComponent(out Enemy enemy))
                {
                    Shoot(enemy.transform);
                    break;
                }
            }
        }

        private void Shoot(Transform target)
        {
            if (_bulletPrefab == null || _firePoint == null) return;

            GameObject bulletObj = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target, CurrentDamage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
        
        public float GetCurrentDamage()
        {
            return CurrentDamage;
        }
    }
}
