using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private int _damage;

    public void SetVelocity(Vector3 velocity)
    {
        _rb.linearVelocity = velocity;
    }

    public void SetDamage(int amount)
    {
        _damage = amount;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {

        }

        _rb.linearVelocity.Set(0,0,0);
        this.gameObject.SetActive(false);
    }
}
