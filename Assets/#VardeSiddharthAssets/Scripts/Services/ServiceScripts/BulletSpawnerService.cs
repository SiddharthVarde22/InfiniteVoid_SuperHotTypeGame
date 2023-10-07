using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerService : MonoBehaviour, IGameService
{
    private GenericObjectPool<BulletView> bulletObjectPool = new GenericObjectPool<BulletView>();

    [SerializeField]
    BulletView bulletView;

    private void OnEnable()
    {
        RegisterServive(TypesOfService.BulletSpawner, this);
    }

    public void RegisterServive(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<BulletSpawnerService>(typesOfService, (BulletSpawnerService)gameService);
    }

    public void CreateBullet(Transform bulletSpawnPoint)
    {
        BulletView bullet = bulletObjectPool.GetObjectFromPool();

        if(bullet == null)
        {
            bullet = Instantiate<BulletView>(bulletView);
        }

        bullet.Enable(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    public void DisableBullet(BulletView bulletView)
    {
        bulletObjectPool.ReturnObjectInPool(bulletView);
    }
}
