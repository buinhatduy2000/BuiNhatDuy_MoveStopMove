using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Character>
{
    public void OnEnter(Character t)
    {
        Bot bot = t as Bot;
        bot.ChangeAnimation("run");
    }

    public void OnExecute(Character t)
    {
        Bot bot = t as Bot;
        if (
            Vector3.Distance(bot.m_Tranform.position, bot.Target) > 0.1f
            || !bot.IsCharacterInAttackRange()
        )
        {
            bot.NavMeshAgent.SetDestination(bot.Target);
        }
        else
        {
            bot.ChangeState(new IdleState());
        }
    }

    public void OnExit(Character t)
    {
        Bot bot = t as Bot;
    }
}
