using System;
using Enemies;
using UnityEngine;

internal sealed class PlayerTestClass : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void Update()
    {
        TryAttack(_damage);
    }

    private void TryAttack(float damage)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}