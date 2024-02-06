using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIState
{
    Vector3 destination;

    public AIPatrolState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Patrol enter");
        agent.animator.SetBool("Walk", true);
    }

    public override void OnUpdate()
    {
        // move towards destination, go to idle if reached
        if (Vector3.Distance(agent.transform.position, agent.nav.path.destination) < 0.95f)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }

        var enemies = agent.enemyPerception.GetGameObjects();
        if (enemies.Length > 0)
        {
            agent.stateMachine.SetState(nameof(AIChaseState));
        }
    }

    public override void OnExit()
    {
        Debug.Log("Patrol exit");
        agent.animator.SetBool("Walk", false);
    }
}

