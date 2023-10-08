using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour, IDamagable
{
    EnemyController enemyController;
    [SerializeField]
    EnemyStateMachine enemyStateMachine;
    [SerializeField]
    EnemyGun_HandGun enemyGun;

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void EnableEnemy()
    {
        gameObject.SetActive(true);
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        ServiceLocator.Instance.GetService<GunSpawnerService>(TypesOfService.GunSpawner).SpawnAGun(transform.position + Vector3.up * 1);
        //Spawn Particles
    }

    public void ChangeEnemyState(TypesOfEnemyStates enemyState)
    {
        enemyStateMachine.ChangeEnemyState(enemyController, enemyState);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerView playerView;

        if(other.TryGetComponent<PlayerView>(out playerView))
        {
            enemyController.SetEnemyState(TypesOfEnemyStates.Attack);
        }
    }

    public void Shoot()
    {
        enemyGun.Shoot();
    }

    public void GetDamage()
    {
        enemyController.DisableEnemy();
        ServiceLocator.Instance.GetService<ParticleSpawnerService>(TypesOfService.ParticleSpawner).
            GetParticles(transform.position + Vector3.up * 1);
    }
}
