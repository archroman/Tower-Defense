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
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position,
                _speed * Time.deltaTime);
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