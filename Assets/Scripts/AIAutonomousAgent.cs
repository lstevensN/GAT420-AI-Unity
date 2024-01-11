using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAutomousAgent : AIAgent
{
    public AIPerception perception = null;

    private void Update()
    {
        // seek
        var gameObjects = perception.GetGameObjects();
        if (gameObjects.Length > 0 )
        {
            movement.ApplyForce(Seek(gameObjects[0]));
        }

        transform.position = Utilities.Wrap(transform.position, new Vector3(-10, -10, -10 ), new Vector3(10, 10, 10));
    }

    private Vector3 Seek(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
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
