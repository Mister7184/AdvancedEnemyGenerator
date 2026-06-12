using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private TargetMover _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, _target.transform.position, _speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
    }

    public void SetTarget(TargetMover target)
    {
        Debug.Log("СетТаргет");

        _target = target;
    }

}