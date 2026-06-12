using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private bool _canMove;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove == false)
            return;

        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, _target.position, _speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
    }

    public void MoveTo(Transform target)
    {
        _canMove = true;

        _target = target;
    }

}