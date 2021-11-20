using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem shootingParticles;
    Transform target;
    Enemy[] enemies;

    void Update()
    {
        FindClosestEnemy();
        AimAndAttackWeapon();
    }

    void FindClosestEnemy()
    {
        enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < closestDistance)
            {
                closestTarget = enemy.transform;
                closestDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimAndAttackWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        weapon.transform.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = shootingParticles.emission;
        emissionModule.enabled = isActive;
    }
}
