using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    EnemyView enemyView;
    TypesOfEnemyStates currentEnemyState = TypesOfEnemyStates.None;
    public EnemyController(EnemyView enemyView)
    {
        currentEnemyState = TypesOfEnemyStates.None;
        this.enemyView = enemyView;
        this.enemyView.SetEnemyController(this);
    }

    public void EnableEnemy(Vector3 position)
    {
        enemyView.transform.position = position;
        enemyView.EnableEnemy();
        if(currentEnemyState == TypesOfEnemyStates.None)
        {
            SetEnemyState(TypesOfEnemyStates.Petrol);
        }
        else
        {
            SetEnemyState(TypesOfEnemyStates.Attack);
        }
    }

    public void DisableEnemy()
    {
        enemyView.DisableEnemy();
        ServiceLocator.Instance.GetService<EnemySpawnerService>(TypesOfService.EnemySpawner).DisableEnemy(this);
        ServiceLocator.Instance.GetService<EventService>(TypesOfService.EventsService).OnCombatStartedEventTrigger();
    }

    public void SetEnemyState(TypesOfEnemyStates enemyState)
    {
        currentEnemyState = enemyState;
        enemyView.ChangeEnemyState(currentEnemyState);
    }

    public void Shoot()
    {
        enemyView.Shoot();
    }
}
