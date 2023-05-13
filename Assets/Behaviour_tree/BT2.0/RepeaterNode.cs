using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Sprites.Packer;

public class RepeaterNode : ParentNode
{
    public override States Execute()
    {
        for (int i = 0; i < children.Count;)
        {
            States result = children[i].Execute();
            if (result == States.Failure)
            {
                ResettingExecution(this); //if a child fails, repeater node will resets states of all nodes (parent and children)
                Debug.Log("behaviour tree failed, retrying...");

                i = 0; //restart the iteration from the first child node
                continue; //continue to the next iteration of the loop without executing the rest of the loop body
            }
            if (result == States.Success)
            {
                i++; //increments the iteration to move to next child node
                executed = true; //child has been executed
                Debug.Log("behaviour tree successfull");
                return States.Success; 
            }
        }
        return States.Default; //If child doesnt return success or fail, returns default.
    }
}
