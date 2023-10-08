using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun_HandGun : MonoBehaviour, IShooter
{
    [SerializeField]
    Transform bulletSpawnPoint;

    public void Shoot()
    {
        ServiceLocator.Instance.GetService<BulletSpawnerService>(TypesOfService.BulletSpawner).CreateBullet(bulletSpawnPoint);
    }
}
