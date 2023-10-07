using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsCollectorService : MonoBehaviour, IGameService
{
    public PlayerView playerView;

    private void OnEnable()
    {
        RegisterService(TypesOfService.CollecterService, this);
    }
    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<GameObjectsCollectorService>(typesOfService, (GameObjectsCollectorService)gameService);
    }
}
