using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Chase")]
public class ChaseAction : Actions {

    public override void Act(FiniteStateMachine fsm)
    {
        //fsm.GetNavMeshAgent().ReduceEnergy(2*Time.deltaTime);
        //Debug.Log(fsm.GetNavMeshAgent().GetEnergy());
        Debug.Log("Chase!"); 
        if (fsm.GetNavMeshAgent().IsAtDestionation())
            fsm.GetNavMeshAgent().GoToTarget();
    }
}
