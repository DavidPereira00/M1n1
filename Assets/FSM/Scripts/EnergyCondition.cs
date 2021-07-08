using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Energy")]
public class EnergyCondition : Condition {

    [SerializeField]
    private bool isGreater;
    [SerializeField]
    private float energyLevel;
   
    public override bool Test(FiniteStateMachine fsm)
    {
        float currEnergy = fsm.GetNavMeshAgent().GetEnergy();
        if (isGreater)
            return currEnergy > energyLevel;
        else return currEnergy < energyLevel;
    }
}
