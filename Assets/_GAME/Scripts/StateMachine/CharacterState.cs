using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    private static IdleState m_Instance;
    public static IdleState Instance => m_Instance ??= new IdleState();

    public void OnEnter(Character go)
    {
        go.OnEnterIdleState();
    }

    public void OnExecute(Character go)
    {
        go.OnExecuteIdleState();
    }

    public void OnExit(Character go)
    {
        go.OnExitIdleState();
    }
}

public class RunState : IState<Character>
{
    private static RunState m_Instance;
    public static RunState Instance => m_Instance ??= new RunState();

    public void OnEnter(Character go)
    {
        go.OnEnterRunState();
    }

    public void OnExecute(Character go)
    {
        go.OnExecuteRunState();
    }

    public void OnExit(Character go)
    {
        go.OnExitRunState();
    }
}

public class AttackState : IState<Character>
{
    private static AttackState m_Instance;
    public static AttackState Instance => m_Instance ??= new AttackState();

    public void OnEnter(Character go)
    {
        go.OnEnterAttackState();
    }

    public void OnExecute(Character go)
    {
        go.OnExecuteAttackState();
    }

    public void OnExit(Character go)
    {
        go.OnExitAttackState();
    }
}

public class DeadState : IState<Character>
{
    private static DeadState m_Instance;
    public static DeadState Instance => m_Instance ??= new DeadState();

    public void OnEnter(Character go)
    {
        go.OnEnterDeadState();
    }

    public void OnExecute(Character go)
    {
        go.OnExecuteDeadState();
    }

    public void OnExit(Character go)
    {
        go.OnExitDeadState();
    }
}
