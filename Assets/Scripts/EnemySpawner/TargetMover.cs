using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _speed = 1f;

    private int _pointIndex;
    private float _closerPointDistance = 0.1f;

    private void Update()
    {
        if (_wayPoints.Count == 0)
            return;

        Transform point = _wayPoints[_pointIndex];

        transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, point.position) < _closerPointDistance)
            _pointIndex = (_pointIndex + 1) % _wayPoints.Count;
    }
}
