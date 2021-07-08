using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour {

    public State initialState;
    private State currentState;
    private MyNavMeshAgent navMeshAgent;       

    void Start () {
        currentState = initialState;
        navMeshAgent = GetComponent<MyNavMeshAgent>();
    }

    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition t in currentState.GetTransitions())
        {
            if (t.IsTriggered(this))
            {
                triggeredTransition = t;
                break;
            }
        }
        List<Actions> actions = new List<Actions>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach (Actions a in currentState.GetActions())
            {
               actions.Add(a);
            }
        }
        DoActions(actions);
    }

    public MyNavMeshAgent GetNavMeshAgent()
    {
        return navMeshAgent;
    }

    void DoActions(List<Actions> actions)
    {
        foreach (Actions a in actions)
        {
            if (a != null)
                a.Act(this);
        }
    }
}
