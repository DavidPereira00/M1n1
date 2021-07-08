using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject{

    [SerializeField]
    private Actions entryAction;
    [SerializeField]
    private Actions[] stateActions;
    [SerializeField]
    private Actions exitAction;
    [SerializeField]
    private Transition[] transitions;

    public Actions[] GetActions()
    {
        return stateActions;
    }
    public Actions GetEntryAction()
    {
        return entryAction;
    }
    public Actions GetExitAction()
    {
        return exitAction;
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }

}
