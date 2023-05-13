using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : ParentNode
{
    public override States Execute()
    {
        
        foreach (BTNode child in children) //loop over chldren of selector node
        {
            States result = child.Execute();

            if (result != States.Failure)
            {
                executed = true;
                return result; //returns result of the child (it'll be either success or running)
            }
        }
        executed = true; 
        return States.Failure; //If none of the child nodes return a success or running, return failure.
    }

    
}

