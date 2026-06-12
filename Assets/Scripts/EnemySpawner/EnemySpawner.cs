using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;
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
            enemy.LifeTimeEnded += OnLifeTimeEnded;

            enemy.transform.position = _spawnPoint.position;

            enemy.SetTarget(_target);

            yield return _spawnDelay;
        }
    }

    private void OnLifeTimeEnded(Enemy enemy)
    {
        enemy.LifeTimeEnded -= OnLifeTimeEnded;
        _pool.Release(enemy);
    }
}