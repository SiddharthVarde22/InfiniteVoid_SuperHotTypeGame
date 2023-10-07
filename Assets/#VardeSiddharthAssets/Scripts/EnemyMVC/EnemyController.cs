using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    EnemyView enemyView;
    public EnemyController(EnemyView enemyView)
    {
        this.enemyView = enemyView;
        this.enemyView.SetEnemyController(this);
    }

    public void EnableEnemy(Vector3 position)
    {
        enemyView.transform.position = position;
        enemyView.gameObject.SetActive(true);
    }

    public void DisableEnemy()
    {
        enemyView.gameObject.SetActive(false);
        ServiceLocator.Instance.GetService<EnemySpawnerService>(TypesOfService.EnemySpawner).DisableEnemy(this);
    }
}
