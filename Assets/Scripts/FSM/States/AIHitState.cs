using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHitState : AIState
{
    float timer = 0;

    public AIHitState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.animator?.SetTrigger("Hit");
        timer = Time.time + 2;
        agent.nav.enabled = false;
        agent.movement.Velocity = Vector3.zero;
    }

    public override void OnUpdate()
    {
        if (Time.time > timer)
        {
            agent.stateMachine.SetState(nameof(AIPatrolState));
        }
    }

    public override void OnExit()
    {
        agent.nav.enabled = true;
    }
}

