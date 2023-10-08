
using UnityEngine;

public abstract class BaseEnemyState
{
    public abstract void OnStateEnter();
    public abstract void UpdateState();
    public abstract void OnStateExit();
}
