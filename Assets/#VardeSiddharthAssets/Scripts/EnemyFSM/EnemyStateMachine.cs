using UnityEngine.AI;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    Animator enemyAnimator;
    [SerializeField]
    private int minXposition = -30, maxXPosition = 30, minZPosition = -30, maxZPosition = 30;
    [SerializeField]
    private int distanceToStopFromPlayer = 15;
    [SerializeField]
    private float timeIntervalToShoot = 0.5f;

    private EnemyController enemyController = null;
    private BaseEnemyState currentEnemyState = null;

    public void ChangeEnemyState(EnemyController enemyController, TypesOfEnemyStates enemyState)
    {
        this.enemyController = enemyController;
        if(currentEnemyState != null)
        {
            currentEnemyState.OnStateExit();
            currentEnemyState = null;
        }

        switch(enemyState)
        {
            case TypesOfEnemyStates.Petrol:
                currentEnemyState = new PetrolEnemyState(
                    enemyController, navMeshAgent, enemyAnimator, minXposition, maxXPosition, minZPosition, maxZPosition);
                break;
            case TypesOfEnemyStates.Attack:
                currentEnemyState = new AttackEnemyState(enemyController, navMeshAgent, enemyAnimator, transform,
                    distanceToStopFromPlayer, timeIntervalToShoot);
                break;
        }

        currentEnemyState.OnStateEnter();
    }

    private void Update()
    {
        currentEnemyState?.UpdateState();
    }
}
