using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour, IInteractable, IShooter
{
    ShootFromWeapon parentWeponSlot;

    [SerializeField]
    Transform bulletShootPoint;
    [SerializeField]
    Rigidbody gunRigidbody;
    [SerializeField]
    float intervalToShootBullet = 0.25f;
    [SerializeField]
    Light pointLight;

    bool canShoot = true;
    int remainingNumberOfBullets = 5;
    float timeToShoot = 0;

    public void OnInteraction(Transform parentTransform)
    {
        transform.parent = parentTransform;
        transform.SetPositionAndRotation(parentTransform.position, parentTransform.rotation);
        parentWeponSlot = parentTransform.GetComponent<ShootFromWeapon>();
        parentWeponSlot.SetWeonToShoot(this);
        parentWeponSlot.RegisterToShootEvent();
        gunRigidbody.isKinematic = true;
        transform.GetComponent<BoxCollider>().isTrigger = true;
        Destroy(pointLight);
    }

    public void Shoot()
    {
        if (canShoot && remainingNumberOfBullets > 0)
        {
            ServiceLocator.Instance.GetService<BulletSpawnerService>(TypesOfService.BulletSpawner).CreateBullet(bulletShootPoint);
            remainingNumberOfBullets--;
            canShoot = false;
            timeToShoot = intervalToShootBullet;
        }
        else if(canShoot && remainingNumberOfBullets <= 0)
        {
            parentWeponSlot.DeRegisterToShootEvent();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(!canShoot)
        {
            timeToShoot -= Time.deltaTime;

            if(timeToShoot <= 0)
            {
                canShoot = true;
                timeToShoot = intervalToShootBullet;
            }
        }
    }
}
