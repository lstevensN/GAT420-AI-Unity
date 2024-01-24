using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AIAutomousAgent : AIAgent
{
    [SerializeField] AIPerception seekPerception = null;
    [SerializeField] AIPerception fleePerception = null;
    [SerializeField] AIPerception flockPerception = null;
    [SerializeField] AIPerception obstaclePerception = null;


    private void Update()
    {
        // seek
        if (seekPerception != null)
        {
            var gameObjects = seekPerception.GetGameObjects();
            if (gameObjects.Length > 0)
            {
                Vector3 force = Seek(gameObjects[0]);
                movement.ApplyForce(force);
            }
        }

        // flee
        if (fleePerception != null)
        {
            var gameObjects = fleePerception.GetGameObjects();
            if (gameObjects.Length > 0)
            {
                Vector3 force = Flee(gameObjects[0]);
                movement.ApplyForce(force);
            }
        }

        // flock
        if (flockPerception != null)
        {
            var gameObjects = flockPerception.GetGameObjects();
            if (gameObjects.Length > 0)
            {
                movement.ApplyForce(Cohesion(gameObjects, 3));
                movement.ApplyForce(Separation(gameObjects, 10));
                movement.ApplyForce(Alignment(gameObjects, 3));
            }
        }

        // obstacle avoidance
        //if (obstaclePerception != null)
        //{
        //    if (((AISphereCastPerception)obstaclePerception).CheckDirection(Vector3.forward))
        //    {
        //        Vector3 open = Vector3.zero;

        //        if (((AISphereCastPerception)obstaclePerception).GetOpenDirection(ref open))
        //        {
        //            movement.ApplyForce(GetSteeringForce(open) * 5);
        //        }
        //    }
        //}

        // cancel y movement
        Vector3 acceleration = movement.Acceleration;
        acceleration.y = 0;
        movement.Acceleration = acceleration;

        // wrap position in world
        transform.position = Utilities.Wrap(transform.position, new Vector3(-20, -20, -20 ), new Vector3(20, 20, 20));
    }

    private Vector3 Seek(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        Vector3 force = GetSteeringForce(direction);

        return force;
    }

    private Vector3 Cohesion(GameObject[] neighbors, float radius)
    {
        Vector3 cohesionDirection = Vector3.zero;
        int cohesionCount = 0;

        foreach (var neighbor in neighbors)
        {
            var distance = Vector3.Distance(neighbor.transform.position, transform.position);
            if (distance < radius)
            {
                cohesionDirection += neighbor.transform.position - transform.position;
                cohesionCount++;
            }
        }

        if (cohesionCount > 0)
        {
            cohesionDirection /= cohesionCount;
        }

        cohesionDirection -= transform.position;

        Vector3 force = GetSteeringForce(cohesionDirection * 0.16f);

        return force;
    }

    private Vector3 Separation(GameObject[] neighbors, float radius)
    {
        Vector3 separationDirection = Vector3.zero;
        int separationCount = 0;

        foreach (var neighbor in neighbors)
        {
            var distance = Vector3.Distance(neighbor.transform.position, transform.position);
            if (distance < radius) 
            {
                separationDirection += neighbor.transform.position - transform.position;
                separationCount++;
            }
        }

        if (separationCount > 0)
        {
            separationDirection /= separationCount;
        }

        separationDirection = -separationDirection;

        Vector3 force = GetSteeringForce(separationDirection * 0.5f);

        return force;
    }

    private Vector3 Alignment(GameObject[] neighbors, float radius) 
    {
        Vector3 alignmentDirection = Vector3.zero;
        int alignmentCount = 0;

        foreach (var neighbor in neighbors)
        {
            var distance = Vector3.Distance(neighbor.transform.position, transform.position);
            if (distance < radius)
            {
                alignmentDirection += neighbor.transform.forward;
                alignmentCount++;
            }
        }

        if (alignmentCount > 0)
        {
            alignmentDirection /= alignmentCount;
        }

        Vector3 force = GetSteeringForce(alignmentDirection * 0.34f);

        return force;
    }

    private Vector3 Flee(GameObject target)
    {
        Vector3 direction = transform.position - target.transform.position;
        return GetSteeringForce(direction);
    }

    private Vector3 GetSteeringForce(Vector3 direction)
    {
        Vector3 desired = direction.normalized * movement.maxSpeed;
        Vector3 steer = desired - movement.Velocity;
        Vector3 force = Vector3.ClampMagnitude(steer, movement.maxForce);

        return force;
    }
}
