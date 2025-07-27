using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    internal sealed class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private List<Transform> _waypoints;

        private int _currentWaypointIndex;

        public void Init(List<Transform> waypoints)
        {
            _waypoints = waypoints;
        }

        private void Update()
        {
            CheckEnemyPosition();
            Move();
        }

        private void Move()
        {
            Vector3 targetPosition = _waypoints[_currentWaypointIndex].position;
            Vector3 direction = targetPosition - transform.position;

            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }


        private void CheckEnemyPosition()
        {
            if (transform.position == _waypoints[_currentWaypointIndex].position &&
                _currentWaypointIndex < _waypoints.Count - 1)
            {
                _currentWaypointIndex++;
            }
        }
    }
}