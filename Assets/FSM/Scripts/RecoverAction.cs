using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Recover")]
public class RecoverAction : Actions {
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetNavMeshAgent().RechargeEnergy(5*Time.deltaTime);
    }
}
