using Enemies;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _bulletSpeed;

        private Transform _target;
        private float _damage;

        public void SetTarget(Transform target, float damage)
        {
            _target = target;
            _damage = damage;
        }

        private void Update()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 direction = (_target.position - transform.position).normalized;
            transform.position += direction * (_bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == _target && other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}