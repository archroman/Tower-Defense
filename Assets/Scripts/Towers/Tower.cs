using Enemies;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] protected float _damage;
        [SerializeField] protected float _attackRange;
        [SerializeField] protected float _attackDelay;

        [SerializeField] protected LayerMask _enemyLayer;

        [SerializeField] protected GameObject _bulletPrefab;
        [SerializeField] protected Transform _firePoint;

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

        protected virtual void TryAttack()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out Enemy enemy))
                {
                    Shoot(enemy.transform);
                    break;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }

        private void Shoot(Transform target)
        {
            GameObject bulletObj = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.SetTarget(target, _damage);
        }
    }
}