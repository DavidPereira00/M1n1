using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Can See")]
public class CanSeeCondition : Condition {

    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;

    public override bool Test(FiniteStateMachine fsm)
    {
        Transform target = fsm.GetNavMeshAgent().target;
        Vector3 targetDir = target.position - fsm.transform.position; 
        float angle = Vector3.Angle(targetDir, fsm.transform.forward);
        float dist = Vector3.Distance(target.position, fsm.transform.position);

        if ((dist < viewDistance))
        {
            if (negation)
                return false;
            else
                return true;
        }
        else
        {
            if (negation)
                return true;
            else
                return false;
        }
         
    }
}
