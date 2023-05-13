using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : ParentNode
{
    public override States Execute()
    {
        States result = States.Running;
        Debug.Log("currently in sequence node");
        foreach (BTNode child in children)
        {
            result = child.Execute();

            if (result == States.Failure)
            {
                Debug.Log("sequence has failed");
                result = States.Failure;
                executed = true;
                return States.Failure;
            }

            if (result == States.Success)
            {
                result = States.Success;
                continue;
            }
        }
        if (result == States.Running)
            return States.Running;
        Debug.Log("sequence is success");
        nodeState = States.Success;
        executed = true;
        return States.Success;
    }
}
