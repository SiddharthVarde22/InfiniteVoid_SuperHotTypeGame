using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    EnemyController enemyController;

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}
