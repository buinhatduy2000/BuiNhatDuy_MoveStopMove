using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent
    {
        get => navMeshAgent;
    }

    [SerializeField]
    private Vector3 target;

    [HideInInspector]
    public Vector3 Target
    {
        get => target;
        set => target = value;
    }

    [SerializeField]
    private float maxDistance = 20f;

    [HideInInspector]
    public float MaxDistance
    {
        get => maxDistance;
        set => maxDistance = value;
    }

    private Transform tf;
    public Transform m_Tranform
    {
        get
        {
            if (tf == null)
            {
                tf = transform;
            }
            return tf;
        }
    }

    /*
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
        ChangeAnimation("idle");
        StartCoroutine(ChangeMoveStateAfterDelay(3f));
    }

    public void OnExecuteIdleState()
    {
        if (IsCharacterInAttackRange())
        {
            stateMachine.ChangeState(AttackState.Instance);
        }
    }

    public void OnExitIdleState() { }

    private IEnumerator ChangeMoveStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!IsCharacterInAttackRange())
        {
            Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
            randomDirection += transform.position;
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(randomDirection, out navHit, maxDistance, NavMesh.AllAreas))
            {
                target = navHit.position;
            }
            stateMachine.ChangeState(MoveState.Instance);
        }
    }
    #endregion

    #region Move State
    public void OnEnterMoveState()
    {
        ChangeAnimation("run");
    }

    public void OnExecuteMoveState()
    {
        if (IsCharacterInAttackRange())
        {
            stateMachine.ChangeState(IdleState.Instance);
        }
        else
        {
            if (Vector3.Distance(this.transform.position, target) > 0.1f)
            {
                navMeshAgent.SetDestination(target);
            }
            else
            {
                stateMachine.ChangeState(IdleState.Instance);
            }
        }
    }

    public void OnExitMoveState() { }
    #endregion

    #region Attack State
    public void OnEnterAttackState()
    {
        Attack();
    }

    public void OnExecuteAttackState()
    {
        if (!IsCharacterInAttackRange())
        {
            stateMachine.ChangeState(IdleState.Instance);
        }
        else
        {
            Attack();
        }
    }

    public void OnExitAttackState() { }
    #endregion
    #endregion
    */
}
