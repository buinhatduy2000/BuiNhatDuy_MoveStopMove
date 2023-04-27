using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
