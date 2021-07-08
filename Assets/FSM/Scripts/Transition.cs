using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transition")]
public class Transition : ScriptableObject{
    [SerializeField]
    private Condition decision;
    [SerializeField]
    private Actions action;
    [SerializeField]
    private State targetState;

    public bool IsTriggered(FiniteStateMachine fsm)
    {
        return decision.Test(fsm);
    }

    public State GetTargetState()
    {
        return targetState;
    }

    public Actions GetAction()
    {
        return action;
    }

   


}
