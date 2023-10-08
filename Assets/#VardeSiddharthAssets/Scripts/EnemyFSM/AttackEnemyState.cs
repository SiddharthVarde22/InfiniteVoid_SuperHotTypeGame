using UnityEngine.AI;
using UnityEngine;

public class AttackEnemyState : BaseEnemyState
{
    NavMeshAgent navMeshAgent;
    EnemyController enemyController;
    Animator enemyAnimator;
    Transform enemyTransform;
    float distanceToStopFromPlayer;
    float timeIntervalToShoot;

    Transform playerTransform;
    float timetoWaitToShoot;

    public AttackEnemyState(EnemyController enemyController, NavMeshAgent navMeshAgent, Animator animator, Transform enemyTransform,
        float distanceToStopFromPlayer, float timeIntervalToShoot)
    {
        this.enemyController = enemyController;
        this.navMeshAgent = navMeshAgent;
        this.enemyAnimator = animator;
        this.enemyTransform = enemyTransform;
        this.distanceToStopFromPlayer = distanceToStopFromPlayer;
        this.timeIntervalToShoot = timeIntervalToShoot;
    }

    public override void OnStateEnter()
    {
        playerTransform = ServiceLocator.Instance.GetService<GameObjectsCollectorService>(
            TypesOfService.CollecterService).playerView.GetComponent<Transform>();
        timetoWaitToShoot = timeIntervalToShoot;

        enemyAnimator.Play("EnemyShoot");
        navMeshAgent.ResetPath();
    }

    public override void OnStateExit()
    {
        navMeshAgent.ResetPath();
    }

    public override void UpdateState()
    {
        if(CheckIfIsTooFarFromPlayer())
        {
            navMeshAgent.destination = playerTransform.position;
        }
        else
        {
            navMeshAgent.ResetPath();
            enemyTransform.LookAt(playerTransform);
            timetoWaitToShoot -= Time.deltaTime;
            if(timetoWaitToShoot <= 0)
            {
                Shoot();
            }
        }
    }

    private bool CheckIfIsTooFarFromPlayer()
    {
        return Vector3.Distance(enemyTransform.position, playerTransform.position) > distanceToStopFromPlayer;
    }

    private void Shoot()
    {
        enemyController.Shoot();
        timetoWaitToShoot = timeIntervalToShoot;
    }
}
