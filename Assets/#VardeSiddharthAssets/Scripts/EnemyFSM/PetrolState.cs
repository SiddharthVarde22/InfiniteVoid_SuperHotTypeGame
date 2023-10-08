using UnityEngine.AI;
using UnityEngine;

public class PetrolState : BaseEnemyState
{
    EnemyController enemyController;
    NavMeshAgent navMeshAgent;
    Vector3 randomTargetPosition;
    int maxXposition, minXPosition, maxZPosition, minZPosition;

    public PetrolState(EnemyController enemyController,NavMeshAgent navMeshAgent,int maxX, int minX,int maxZ, int minZ)
    {
        this.enemyController = enemyController;
        this.navMeshAgent = navMeshAgent;
        this.maxXposition = maxX;
        this.minXPosition = minX;
        this.maxZPosition = maxZ;
        this.minZPosition = minZ;
    }
    public override void OnStateEnter()
    {
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
        //tell controller to delete collider
        //tell controller to go to attack state
    }
}
