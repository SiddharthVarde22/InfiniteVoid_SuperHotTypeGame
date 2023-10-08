
using UnityEngine;

public class ShootFromWeapon : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;

    IShooter weponThatCanShoot;

    public void RegisterToShootEvent()
    {
        ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService).OnShootPressedEvent += OnShootEventTriggered;
        playerView.SetHasGun(true);
    }

    public void DeRegisterToShootEvent()
    {
        ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService).OnShootPressedEvent -= OnShootEventTriggered;
        playerView.SetHasGun(false);
    }

    public void OnShootEventTriggered()
    {
        playerView.OnPlayerShootsBullet();
        weponThatCanShoot.Shoot();
    }

    public void SetWeonToShoot(IShooter shooterWepon)
    {
        this.weponThatCanShoot = shooterWepon;
    }
}
