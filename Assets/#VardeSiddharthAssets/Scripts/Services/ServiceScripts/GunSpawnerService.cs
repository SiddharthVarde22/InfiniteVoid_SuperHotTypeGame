
using UnityEngine;

public class GunSpawnerService : MonoBehaviour, IGameService
{
    [SerializeField]
    HandGun handGunPrefab;

    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<GunSpawnerService>(typesOfService, (GunSpawnerService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfService.GunSpawner, this);
    }

    public void SpawnAGun(Vector3 position)
    {
        Instantiate<HandGun>(handGunPrefab, position, Quaternion.identity);
    }
}
