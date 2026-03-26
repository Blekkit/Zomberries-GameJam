using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHP;

    private int _currentHP;

    public void TakeDamage(int amount)
    {
        _currentHP -= amount;
        if (_currentHP <= 0)
            Destroy(gameObject);
    }

    private void Awake()
    {
        _currentHP = _maxHP;
    }
}
