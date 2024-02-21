using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    float timer;
    int path;

    public AIIdleState(AIStateAgent agent) : base(agent)
    {
        //AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
        //transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));

        //transitions.Add(transition);

        //transition = new AIStateTransition(nameof(AIChaseState));
        //transition.AddCondition(new BoolCondition(agent.enemySeen));

        //transitions.Add(transition);
    }

    public override void OnEnter()
    {
        Debug.Log("Idle enter");

        Random.seed = System.DateTime.Now.Millisecond;

        path = Random.Range(0, 7);
        // agent.timer.value = Random.Range(2, 5);
        timer = Time.time + Random.Range(2, 5);
        agent.animator.SetBool("Idle", true);

        agent.nav.enabled = false;
    }

    public override void OnExit()
    {
        Debug.Log("Idle exit");
        agent.animator.SetBool("Idle", false);

        agent.nav.enabled = true;
    }

    public override void OnUpdate()
    {
        agent.movement.Velocity = Vector3.zero;

        // if (transition.ToTransition()) agent.stateMachine.SetState(transition.nextState);

        if (Time.time > timer)
        {
            if (path != 1) agent.stateMachine.SetState(nameof(AIPatrolState));
            else agent.stateMachine.SetState(nameof(AIDanceState));
        }

        var friends = agent.friendPerception.GetGameObjects();
        if (friends.Length > 0) agent.stateMachine.SetState(nameof(AIWaveState));
    }
}

