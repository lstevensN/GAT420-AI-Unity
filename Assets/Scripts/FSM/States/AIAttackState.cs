using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIState
{
    float timer = 0;

    public AIAttackState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.animator.SetBool("Attack", true);
        timer = Time.time + 2;

        Debug.Log("Attack enter");
        Attack();

        agent.nav.enabled = false;
    }

    public override void OnUpdate()
    {
        // Debug.Log("Attack update");
        agent.movement.Velocity = Vector3.zero;

        if (Time.time > timer)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }
    }

    public override void OnExit()
    {
        Debug.Log("Attack exit");
        agent.animator.SetBool("Attack", false);

        agent.nav.enabled = true;
    }

    private void Attack()
    {
        // check for collision with surroundings
        var colliders = Physics.OverlapSphere(agent.transform.position, 1);
        foreach (var collider in colliders)
        {
            // don't hit self or objects with the same tag
            if (collider.gameObject == agent.gameObject || collider.gameObject.CompareTag(agent.gameObject.tag)) continue;

            // check if collider object is a state agent, reduce health
            if (collider.gameObject.TryGetComponent<AIStateAgent>(out var stateAgent))
            {
                stateAgent.ApplyDamage(Random.Range(20, 50));
            }
        }
    }
}
