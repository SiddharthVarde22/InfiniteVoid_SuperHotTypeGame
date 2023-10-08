using UnityEngine.AI;
using UnityEngine;

public class PetrolEnemyState : BaseEnemyState
{
    EnemyController enemyController;
    Animator enemyAnimator;
    NavMeshAgent navMeshAgent;
    Vector3 randomTargetPosition;
    int maxXposition, minXPosition, maxZPosition, minZPosition;

    public PetrolEnemyState(EnemyController enemyController, NavMeshAgent navMeshAgent, Animator enemyAnimator,
        int maxX, int minX, int maxZ, int minZ)
    {
        this.enemyController = enemyController;
        this.navMeshAgent = navMeshAgent;
        this.enemyAnimator = enemyAnimator;
        this.maxXposition = maxX;
        this.minXPosition = minX;
        this.maxZPosition = maxZ;
        this.minZPosition = minZ;
    }
    public override void OnStateEnter()
    {
        enemyAnimator.Play("Run");
        ChangeTargetPosition();
        ServiceLocator.Instance.GetService<EventService>(TypesOfService.EventsService).OnCombatStartedEvent += OnCombatStarted;
    }

    public override void OnStateExit()
    {
        ServiceLocator.Instance.GetService<EventService>(TypesOfService.EventsService).OnCombatStartedEvent -= OnCombatStarted;
    }

    public override void UpdateState()
    {
        if(!navMeshAgent.hasPath)
        {
            ChangeTargetPosition();
        }
    }

    private void ChangeTargetPosition()
    {
        randomTargetPosition.x = Random.Range(minXPosition, maxXposition);
        randomTargetPosition.y = 0;
        randomTargetPosition.z = Random.Range(minZPosition, maxZPosition);
        navMeshAgent.SetDestination(randomTargetPosition);
    }

    private void OnCombatStarted()
    {
        //tell controller to go to attack state
    }
}
