using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Queue<T> _objects = new Queue<T>();
    private T _prefab;

    public Pool(T prefab, int startSize)
    {
        _prefab = prefab;

        for (int i = 0; i < startSize; i++)
        {
            Create();
        }
    }

    private void Create()
    {
        T objectForPool = Object.Instantiate(_prefab);

        objectForPool.gameObject.SetActive(false);
        _objects.Enqueue(objectForPool);
    }

    public T Get()
    {
        if (_objects.Count == 0)
            Create();

        T objectForPool = _objects.Dequeue();
        objectForPool.gameObject.SetActive(true);

        return objectForPool;
    }

    public void Release(T objectForPool)
    {
        objectForPool.gameObject.SetActive(false);
        _objects.Enqueue(objectForPool);
    }
}