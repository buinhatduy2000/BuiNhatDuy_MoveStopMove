using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    public void OnEnter(T go);
    public void OnExecute(T go);
    public void OnExit(T go);
}

public class StateMachine<T>
{
    public T m_Owner;
    public IState<T> currentState;

    public StateMachine(T owner)
    {
        m_Owner = owner;
    }

    public void InitState(IState<T> state)
    {
        currentState = state;
        currentState.OnEnter(m_Owner);
    }

    public void ChangeState(IState<T> state)
    {
        currentState.OnExit(m_Owner);
        currentState = state;
        currentState.OnEnter(m_Owner);
    }
}

public class IdleState : IState<Bot>
{
    private static IdleState m_Instance;
    public static IdleState Instance => m_Instance ??= new IdleState();

    public void OnEnter(Bot go)
    {
        go.OnEnterIdleState();
    }

    public void OnExecute(Bot go)
    {
        go.OnExecuteIdleState();
    }

    public void OnExit(Bot go)
    {
        go.OnExitIdleState();
    }
}

public class MoveState : IState<Bot>
{
    private static MoveState m_Instance;
    public static MoveState Instance => m_Instance ??= new MoveState();

    public void OnEnter(Bot go)
    {
        go.OnEnterMoveState();
    }

    public void OnExecute(Bot go)
    {
        go.OnExecuteMoveState();
    }

    public void OnExit(Bot go)
    {
        go.OnExitMoveState();
    }
}

public class AttackState : IState<Bot>
{
    private static AttackState m_Instance;
    public static AttackState Instance => m_Instance ??= new AttackState();

    public void OnEnter(Bot go)
    {
        go.OnEnterAttackState();
    }

    public void OnExecute(Bot go)
    {
        go.OnExecuteAttackState();
    }

    public void OnExit(Bot go)
    {
        go.OnExitAttackState();
    }
}
