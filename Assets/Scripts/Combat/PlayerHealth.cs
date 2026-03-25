using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _gameOverSceneIndex;
    [SerializeField] private int _maxHP;

    private int _currentHP;

    public void TakeDamage(int amount)
    {
        _currentHP -= amount;
        if (_currentHP <= 0)
            GameSceneManager.instance.ChangeScene(_gameOverSceneIndex);
    }

    private void Awake()
    {
        _currentHP = _maxHP;
    }
}
