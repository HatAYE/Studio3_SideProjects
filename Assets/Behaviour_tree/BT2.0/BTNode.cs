using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode
{
    public States nodeState = States.Default;
    public abstract States Execute();
    public bool executed;

    public virtual void ResettingExecution(BTNode node)
    {
        node.executed = false;
    }

    public enum States
    {
        Running, Success, Failure, Default
    }
}

