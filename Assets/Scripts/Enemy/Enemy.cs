using UnityEngine;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _moveSpeed = 1f;

    private Transform _targetTransform;
    private Transform _transform;
    private Rigidbody _rb;

    public void SetTarget(Transform target)
    {
        _targetTransform = target;
    }

    private void MoveToTarget()
    {
        Vector3 direction = (_targetTransform.position - _transform.position).normalized;
        direction *= _moveSpeed;
        direction.y = 0;
        _rb.linearVelocity = direction;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
            Destroy(this.gameObject);
        }
    }
}
