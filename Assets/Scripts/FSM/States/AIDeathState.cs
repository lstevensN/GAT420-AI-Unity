using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    float timer = 0;

    public AIDeathState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.animator?.SetTrigger("Death");
        timer = Time.time + 5;
        agent.nav.enabled = false;
        agent.movement.Velocity = Vector3.zero;
    }

    public override void OnUpdate()
    {
        if (Time.time > timer)
        {
            GameObject.Destroy(agent.gameObject);
        }
    }

    public override void OnExit()
    {

    }
}

