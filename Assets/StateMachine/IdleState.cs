using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : IState<Character>
{
    private float delayPatrol;

    public void OnEnter(Character t)
    {
        Bot bot = t as Bot;
        bot.ChangeAnimation("idle");

        delayPatrol = 10f;
        Vector3 randomDirection = Random.insideUnitSphere * bot.MaxDistance;
        randomDirection += bot.m_Tranform.position;
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, bot.MaxDistance, NavMesh.AllAreas))
        {
            bot.Target = navHit.position;
        }
    }

    public void OnExecute(Character t)
    {
        Bot bot = t as Bot;
        delayPatrol -= Time.deltaTime;

        if (bot.IsCharacterInAttackRange())
        {
            bot.ChangeState(new AttackState());
            return;
        }
        else if (delayPatrol <= 0)
        {
            bot.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Character t) { }
}
