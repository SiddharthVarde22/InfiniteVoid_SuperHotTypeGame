
using UnityEngine;

public class ShootFromWeapon : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;
    [SerializeField]
    float IntervalBetweenTwoShots = 0.2f;
    public void RegisterToShootEvent()
    {
        ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService).OnShootPressedEvent += OnShootEventTriggered;
    }

    public void DeRegisterToShootEvent()
    {
        ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService).OnShootPressedEvent -= OnShootEventTriggered;
    }

    private void OnDisable()
    {
        DeRegisterToShootEvent();
    }
    public void OnShootEventTriggered()
    {
        playerView.OnPlayerShootsBullet();
        //shoot the bullet
    }
}
