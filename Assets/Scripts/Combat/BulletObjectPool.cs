using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _minSize = 10;
    [SerializeField] private int _maxSize = 200;

    private Queue<GameObject> _bulletQueue;

    public static BulletObjectPool Instance;

    public void SpawnBullet(Vector3 position, Quaternion rotation, Vector3 velocity, int damage)
    {
        GameObject bulletObject;

        if (_bulletQueue.Peek().activeSelf && _bulletQueue.Count <= _maxSize)
        {
            bulletObject = Instantiate(_bulletPrefab);
            _bulletQueue.Enqueue(bulletObject);
        }
        else
        {
            bulletObject = _bulletQueue.Dequeue();
        }

        bulletObject.transform.position = position;
        bulletObject.transform.rotation = rotation;
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetVelocity(velocity);
        bullet.SetDamage(damage);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

            _bulletQueue = new Queue<GameObject>();

        for (int i = 0; i <= _minSize; i++)
        {
            GameObject newBullet = Instantiate(_bulletPrefab);
            newBullet.SetActive(false);
            _bulletQueue.Enqueue(newBullet);
        }
    }
}
