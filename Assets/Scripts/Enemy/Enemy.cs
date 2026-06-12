using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private TargetMover _target;

    public Action<Enemy> TouchedTarget;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<TargetMover>(out TargetMover target) == false)
            return;

        if (_target != target)
            return;

        TouchedTarget?.Invoke(this);
    }

    public void StartMoveToTarget(TargetMover target) 
    {
        _target = target;

        _enemyMover.SetTarget(target);
    }
}