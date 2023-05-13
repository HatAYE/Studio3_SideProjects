using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeNode : MonoBehaviour
{

    public abstract NodeStates Execute(TrashCleaningRobot robot);
    protected List<TreeNode> children = new List<TreeNode>();

    public virtual void AddChild(TreeNode child)
    {
        children.Add(child);
    }

    public virtual void RemoveChild(TreeNode child)
    {
        children.Remove(child);
    }

    public virtual void NextBehavior()
    {
        //return children[0];
    }
}

    /*protected NodeStates states;
    public NodeStates States { get { return states; } }
    public abstract NodeStates Testing();
    TreeNode parent=null;
    public List<TreeNode> children= new List<TreeNode>();
    public TreeNode(List<TreeNode> children)
    {
        foreach (TreeNode child in children)
            SetParent(child);
    }
    void SetParent(TreeNode node)
    {
        node.parent = this;
        children.Add(node);

    }*/


//states for the node
public enum NodeStates
    {
        running,
        fail,
        success
    }