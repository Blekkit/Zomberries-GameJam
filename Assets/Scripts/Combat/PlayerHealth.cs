using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _gameOverSceneIndex;
    [SerializeField] private int _maxHP;
    [SerializeField] private TMP_Text _healthText;

    private int _currentHP;

    public void TakeDamage(int amount)
    {
        _currentHP -= amount;
        _healthText.text = $"Current health: {_currentHP}";
        if (_currentHP <= 0)
            GameSceneManager.instance.ChangeScene(_gameOverSceneIndex);
    }

    private void Awake()
    {
        _currentHP = _maxHP;
        _healthText.text = $"Current health: {_currentHP}";
    }
}
