using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerService : MonoBehaviour, IGameService
{
    [SerializeField]
    EnemyView enemyViewPrefab;
    [SerializeField]
    int maxEnemyTogether = 4;
    [SerializeField]
    float maxXPosition = 30, minXPosition = -30, maxZPosition = 30, minZPosition = -30;

    int enemyCount = 0;
    GenericObjectPool<EnemyController> enemyObjectPool = new GenericObjectPool<EnemyController>();
    Vector3 positionForEnemy;

    private void OnEnable()
    {
        RegisterService(TypesOfService.EnemySpawner, this);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < maxEnemyTogether)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        EnemyController enemyController = null;
        enemyController = enemyObjectPool.GetObjectFromPool();

        if(enemyController == null)
        {
            EnemyView enemyView = Instantiate<EnemyView>(enemyViewPrefab);
            enemyController = new EnemyController(enemyView);
        }

        EnableEnemy(enemyController);
        enemyCount++;
    }

    void EnableEnemy(EnemyController enemyController)
    {
        positionForEnemy.x = Random.Range(minXPosition, maxXPosition);
        positionForEnemy.y = 0;
        positionForEnemy.z = Random.Range(minZPosition, maxZPosition);
        enemyController.EnableEnemy(positionForEnemy);
    }

    public void DisableEnemy(EnemyController enemyController)
    {
        enemyObjectPool.ReturnObjectInPool(enemyController);
        enemyCount--;
    }

    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<EnemySpawnerService>(typesOfService, (EnemySpawnerService)gameService);
    }
}
