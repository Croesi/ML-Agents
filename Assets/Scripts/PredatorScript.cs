using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class PredatorScript : Agent
{
    public float maxSpeed;
    public override void OnActionReceived(ActionBuffers actions)
    {
        //base.OnActionReceived(actions);
        //Debug.Log(actions.DiscreteActions[0]);

        Vector3 directionVector = new Vector3(actions.ContinuousActions[0], 0, actions.ContinuousActions[1]);

        Vector3 moveVector = directionVector * maxSpeed * actions.ContinuousActions[2]; //Map(-1, 1, 0, maxSpeed, Mathf.Clamp(actions.ContinuousActions[2], -1f, 1f));
        //Debug.Log("direction" + directionVector);

        //Debug.Log("move" + moveVector);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        base.Heuristic(actionsOut);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
    }

    private float Map(float from, float to, float from2, float to2, float value)
    {
        if (value <= from2)
        {
            return from;
        }
        else if (value >= to2)
        {
            return to;
        }
        else
        {
            return (to - from) * ((value - from2) / (to2 - from2)) + from;
        }
    }

}
