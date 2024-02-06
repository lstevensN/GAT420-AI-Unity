using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDanceState : AIState
{
    Vector3 destination;
    float timer;

    public AIDanceState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Dance enter");
        agent.animator.SetTrigger("Dance");
        timer = Time.time + 10;

        agent.nav.enabled = false;
    }

    public override void OnUpdate()
    {
        if (Time.time > timer)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }
    }

    public override void OnExit()
    {
        Debug.Log("Dance exit");
        agent.animator.SetTrigger("Dance");

        agent.nav.enabled = true;
    }
}

