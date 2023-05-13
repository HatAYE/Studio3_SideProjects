using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNode : BTNode
{
    protected List<BTNode> children= new List<BTNode>();
    public override States Execute()
    {
        return States.Default;
    }
    public override void ResettingExecution(BTNode node)
    {
        base.ResettingExecution(node);

        if (node is ParentNode) // Check if the node is a ParentNode
        {
            ParentNode parentNode = null;

            parentNode = node as ParentNode; // casts this node a ParentNode

            for (int i = 0; i < parentNode.children.Count; i++)
            {
                ResettingExecution(parentNode.children[i]); // uses reccursion to reset each child of the parent node (which in my code, could either be a selector or a sequence node)
            }
        }

        
    }

    public void AddChildren(BTNode child) 
    {
        children.Add(child);
    }

}
