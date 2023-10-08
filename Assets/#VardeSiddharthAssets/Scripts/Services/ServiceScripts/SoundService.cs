using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundService : MonoBehaviour, IGameService
{
    [SerializeField]
    AudioClip gunSoundClip;
    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<SoundService>(TypesOfService.SoundService, (SoundService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfService.SoundService, this);
    }

    public void PlayGunShotSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(gunSoundClip, position);
    }
}
