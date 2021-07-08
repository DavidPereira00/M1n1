using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Patrol")]
public class PatrolAction : Actions{

    public override void Act(FiniteStateMachine fsm)
    {
        //fsm.GetNavMeshAgent().ReduceEnergy(Time.deltaTime);
        Debug.Log("Patrol!");
        if (fsm.GetNavMeshAgent().IsAtDestionation())
            fsm.GetNavMeshAgent().GoToNextWaypoint();
    }
}

