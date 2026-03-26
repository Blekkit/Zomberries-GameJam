using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnCenterPosition;
    [SerializeField] private float _minSpawnDistance = 10f, _maxSpawnDistance = 20f;
    [SerializeField] private float _enemySpawnDelay = 5f;
    [SerializeField] private float _nightSpawnRateMultiplier = 0.2f;
    [SerializeField] private int _baseGroupAmount = 1;
    [SerializeField] private float _groupAmountDayMultiplier = 1f;

    private bool _isNight = false;
    private int _dayCount = 1;

    private void SetDayCount(int value)
    {
        _dayCount = value;
    }

    public void StartNight()
    {
        _isNight = true;
        StartCoroutine(EnemySpawnLoop());
    }

    public void EndNight()
    {
        _isNight = false;
    }

    private IEnumerator EnemySpawnLoop()
    {
        while (_isNight)
        {
            SpawnEnemies(_baseGroupAmount + (int)(_dayCount * _groupAmountDayMultiplier));
            yield return new WaitForSeconds(Mathf.Max(_enemySpawnDelay - _dayCount * _nightSpawnRateMultiplier, 0.1f));
        }
    }

    private void SpawnEnemies(int amount)
    {
        Vector2 spawnOffset = Random.insideUnitCircle.normalized * Random.Range(_minSpawnDistance, _maxSpawnDistance);
        Vector3 spawnPosition = _spawnCenterPosition.position + new Vector3(spawnOffset.x, 0, spawnOffset.y);
        Enemy spawningEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
        spawningEnemy.SetTarget(_spawnCenterPosition);
    }
}
