using System;
using UnityEngine;

public class EventService : MonoBehaviour, IGameService
{
    public event Action OnCombatStartedEvent;

    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<EventService>(typesOfService, (EventService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfService.EventsService, this);
    }

    public void OnCombatStartedEventTrigger()
    {
        OnCombatStartedEvent?.Invoke();
    }
}
