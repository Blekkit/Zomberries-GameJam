using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] private BulletShooter[] _allShooters;

    public void StartAllShooting()
    {
        foreach (BulletShooter shooter in _allShooters)
        {
            shooter.StartFiring();
        }
    }

    public void EndAllshooting()
    {
        foreach (BulletShooter shooter in _allShooters)
        {
            shooter.StopFiring();
        }
    }
}
