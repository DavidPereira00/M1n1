using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour {

    public Transform target;
    public Transform[] waypoints;
    private int currentWaypoint;
    private NavMeshAgent agent;
    private float energy = 100;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		agent.destination = target.position;
        //\agent.destination ;
    }

    public float GetEnergy() {
        return energy;
    }

    public void ReduceEnergy(float energyLost) {
        energy -= energyLost;
    }

    public void RechargeEnergy(float energyWon)
    {
        energy += energyWon;
    }

    public void GoToNextWaypoint()
    {
        agent.destination = waypoints[currentWaypoint].position;
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;
    }

    public void GoToTarget()
    {
        agent.destination = target.position;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public bool IsAtDestionation()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
