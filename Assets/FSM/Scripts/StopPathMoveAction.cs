using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Stop Path Movement")]
public class StopPathMoveAction : Actions{

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetNavMeshAgent().StopAgent();
    }
}

