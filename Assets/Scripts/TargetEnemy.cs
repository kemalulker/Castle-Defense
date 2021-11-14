using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }
}
