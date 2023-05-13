using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : TreeNode
{
    private List<TreeNode> children = new List<TreeNode>();
    private int currentChildIndex = 0;

    public override NodeStates Execute(TrashCleaningRobot robot)
    {
        // Execute the current child behavior
        NodeStates status = children[currentChildIndex].Execute(robot);

        // If the child behavior fails or is still running, return its status
        if (status != NodeStates.success)
        {
            return status;
        }

        // If the current child behavior succeeded, move to the next one
        currentChildIndex++;

        // If there are no more child behaviors, return success
        if (currentChildIndex >= children.Count)
        {
            currentChildIndex = 0;
            return NodeStates.success;
        }

        // If there are more child behaviors, return running
        return NodeStates.running;
    }
    public override void AddChild(TreeNode child)
    {
        children.Add(child);
    }

    
}
