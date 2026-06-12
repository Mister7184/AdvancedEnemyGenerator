using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private TargetMover _target;
    [SerializeField] private Transform _spawnPoint;

    private Pool<Enemy> _pool;
    private int _poolSize = 10;
    private float _spawnDelaySeconds = 2f;
    private bool _isWork = true;
    private WaitForSeconds _spawnDelay;

    private void Start()
    {
        _pool = new Pool<Enemy>(_enemyPrefab, _poolSize);
        _spawnDelay = new WaitForSeconds(_spawnDelaySeconds);
        StartCoroutine(EnemySpawnWithDelay());
    }

    private IEnumerator EnemySpawnWithDelay()
    {
        while (_isWork)
        {
            Enemy enemy = _pool.Get();
            enemy.TouchedTarget += OnTouchedTarget;

            enemy.transform.position = _spawnPoint.position;

            enemy.StartMoveToTarget(_target);

            yield return _spawnDelay;
        }
    }

    private void OnTouchedTarget(Enemy enemy)
    {
        enemy.TouchedTarget -= OnTouchedTarget;
        _pool.Release(enemy);
    }
}