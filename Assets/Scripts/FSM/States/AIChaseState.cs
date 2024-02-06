using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : AIState
{
    float initialSpeed;
    Vector3 tempPosition;

    public AIChaseState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        initialSpeed = agent.movement.maxSpeed;
        agent.movement.maxSpeed *= 3;
        agent.animator.SetBool("Run", true);

        Debug.Log("Chase enter");
        agent.nav.enabled = false;
    }

    public override void OnUpdate()
    {
        var enemies = agent.enemyPerception.GetGameObjects();

        if (enemies.Length > 0)
        {
            var enemy = enemies[0];
            float tempDistance = Vector3.Distance(agent.transform.position, enemy.transform.position);

            for (int i = 0; i < enemies.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, enemies[i].transform.position) < tempDistance) enemy = enemies[i];
            }

            tempPosition = enemy.transform.position;

            if (Vector3.Distance(agent.transform.position, enemy.transform.position) < 1.0f)
            {
                agent.stateMachine.SetState(nameof(AIAttackState));
            }
            else
            {
                agent.movement.MoveTowards(enemy.transform.position);
            }
        }
        else
        {
            agent.movement.MoveTowards(tempPosition);

            if (Vector3.Distance(agent.transform.position, tempPosition) < 1.0f) agent.stateMachine.SetState(nameof(AIPatrolState));
        }
    }

    public override void OnExit()
    {
        agent.movement.maxSpeed = initialSpeed;
        agent.animator.SetBool("Run", false);

        Debug.Log("Chase exit");
        agent.nav.enabled = true;
    }
}

