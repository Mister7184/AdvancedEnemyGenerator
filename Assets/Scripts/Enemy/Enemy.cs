using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private float _lifeTimeSeconds = 3f;
    private WaitForSeconds _lifeTime;

    public Action<Enemy> LifeTimeEnded;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _lifeTime = new WaitForSeconds(_lifeTimeSeconds);
    }

    public void SetTarget(Transform target) 
    {
        _enemyMover.MoveTo(target);

        StartCoroutine(ReturnAfterTime());
    }

    private IEnumerator ReturnAfterTime() 
    {
        yield return _lifeTime;

        LifeTimeEnded?.Invoke(this);
    }
}