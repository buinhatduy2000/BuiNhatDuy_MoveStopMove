using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Vector3 target;
    [SerializeField] private float maxDistance = 20f;

    private StateMachine<Bot> stateMachine;

    public override void Start()
    {
        base.Start();
        navMeshAgent.speed = characterMoveSpeed;

        stateMachine = new StateMachine<Bot>(this);
        stateMachine.InitState(IdleState.Instance);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.currentState.OnExecute(this);
    }

    #region State Functions
    #region Idle State
    public void OnEnterIdleState()
    {
        print("Enter Idle");
        ChangeAnimation("idle");

        Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
        randomDirection += transform.position;
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, maxDistance, NavMesh.AllAreas))
        {
            target = navHit.position;
        }

        StartCoroutine(ChangeMoveStateAfterDelay(3f));
    }
    public void OnExecuteIdleState()
    {
        print("Execute Idle");
        if (!IsCharacterInAttackRange()) return;

        stateMachine.ChangeState(AttackState.Instance);
    }
    public void OnExitIdleState()
    {
        print("Exit Idle");
    }

    private IEnumerator ChangeMoveStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChangeState(MoveState.Instance);
    }
    #endregion

    #region Move State
    public void OnEnterMoveState()
    {
        print("Enter Move");
        ChangeAnimation("run");
    }
    public void OnExecuteMoveState()
    {
        print("Execute Move");
        if (Vector3.Distance(this.transform.position, target) > 0.1f)
        {
            navMeshAgent.SetDestination(target);
        }
        else
        {
            stateMachine.ChangeState(IdleState.Instance);
        }

    }
    public void OnExitMoveState()
    {
        print("Exit Move");
    }
    #endregion

    #region Attack State
    public void OnEnterAttackState()
    {
        print("Enter Attack");
    }
    public void OnExecuteAttackState()
    {
        print("Execute Attack");
    }
    public void OnExitAttackState()
    {
        print("Exit Attack");
    }
    #endregion
    #endregion


}
