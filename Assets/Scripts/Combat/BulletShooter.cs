using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Field _field;
    [SerializeField] private float _bulletDamageLevelMultiplier;
    [SerializeField] private float _baseAttackDelay;
    [SerializeField] private float _attackSpeedLevelMultiplier;

    private bool _isFiring = false;
    private bool _canFire = false;
    private Transform _transform;
    private Vector3 _mousePosition;

    public void SetCanFire(bool value)
    {
        _canFire = value;
    }

    public void StartFiring()
    {
        if (_canFire)
            _isFiring = true;

        StartCoroutine(Shoot());
    }

    public void StopFiring()
    {
        _isFiring = false;
    }

    private IEnumerator Shoot()
    {        
        while (_isFiring)
        {
            FireBullet();
            yield return new WaitForSeconds(_baseAttackDelay - _attackSpeedLevelMultiplier * (int)_field.FieldState);
        } 
    }

    private void FireBullet()
    {
        Vector3 velocity = (_mousePosition - _transform.position).normalized;
        velocity *= _attackSpeedLevelMultiplier * (int)_field.FieldState;
        int damage = (int)((int)_field.FieldState * _bulletDamageLevelMultiplier);
        BulletObjectPool.Instance.SpawnBullet(_transform.position, _transform.rotation, velocity, damage);
    }

    public void UpdateMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(MousePositionProvider.Instance.GetMouseScreenPosition());
    }

    private void Update()
    {
        UpdateMousePosition();
    }

    //private void OnEnable()
    //{
    //    DayNight.instance.turnDay.AddListener(StartFiring());
    //    DayNight.instance.turnNight.AddListener(StopFiring());
    //}

    //private void OnDisable()
    //{
    //    DayNight.instance.turnDay.RemoveListener(StartFiring());
    //    DayNight.instance.turnNight.RemoveListener(StopFiring());
    //}
}
