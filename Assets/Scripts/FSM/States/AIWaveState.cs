using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveState : AIState
{
    Vector3 destination;
    float timer;

    public AIWaveState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Wave enter");
        agent.animator.SetBool("Wave", true);
        timer = Time.time + 2;

        agent.nav.enabled = false;
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
        Debug.Log("Wave exit");
        agent.animator.SetBool("Wave", false);

        agent.nav.enabled = true;
    }
}

