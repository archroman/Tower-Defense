using System;
using Enemies;
using UnityEngine;

namespace Towers
{
    internal sealed class Tower : MonoBehaviour
    {
        [SerializeField] private float _damage;

        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackDelay;

        [SerializeField] private LayerMask _enemyLayer;

        private float _lastAttackTime;

        private void Update()
        {
            _lastAttackTime += Time.deltaTime;

            if (_lastAttackTime >= _attackDelay)
            {
                TryAttack();
                _lastAttackTime = 0;
            }
        }

        private void TryAttack()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(_damage);
                    break;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}