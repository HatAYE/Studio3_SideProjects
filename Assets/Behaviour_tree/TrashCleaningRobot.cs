using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCleaningRobot : MonoBehaviour
{
    public int stateTesting;
    private TreeNode node;

    private bool solidTrashDetected = false;
    private bool liquidTrashDetected = false;

    public bool IsSolidTrashDetected()
    {
        return solidTrashDetected;
    }

    public bool IsLiquidTrashDetected()
    {
        return liquidTrashDetected;
    }

    public void SetSolidTrashDetected(bool value)
    {
        solidTrashDetected = value;
    }

    public void SetLiquidTrashDetected(bool value)
    {
        liquidTrashDetected = value;
    }

    private void Start()
    {
        // Create the behavior tree
        Sequence root = new Sequence();

        // Add the behaviors to the tree
       /* root.AddChild(new IdleBehavior());
        root.AddChild(new WanderBehavior());
        root.AddChild(new ScanForTrashBehavior());

        DetermineTrashTypeBehavior determineTrashType = new DetermineTrashTypeBehavior();
        root.AddChild(determineTrashType);

        root.AddChild(new TakeOutTrashBehavior());

        // Set the root as the current behavior
        currentBehavior = root;*/
    }

    private void Update()
    {
        // Execute the current behavior
        /*BehaviorStatus status = currentBehavior.Execute(this);

        // If the behavior is done, switch to the next behavior
        if (status != BehaviorStatus.Running)
        {
            currentBehavior = currentBehavior == null ? null : currentBehavior.NextBehavior();
        }*/ 
        if (stateTesting == 1)
            Debug.Log("Wander");

        if (stateTesting == 2)
            Debug.Log("Scanning for trash");

        if (stateTesting == 3)
            Debug.Log("Determining trash type");

        if (stateTesting == 4)
            Debug.Log("Selecting whether to pickup or mop");

        if (stateTesting == 5)
            Debug.Log("Taking out trash");
    }
}
public class IdleBehavior : TreeNode
{
    public override NodeStates Execute(TrashCleaningRobot robot)
    {
        if (GetComponent<TrashCleaningRobot>().stateTesting >= 1)
        {
            Debug.Log("Wander");
            return NodeStates.success;
        }
        else return NodeStates.fail;        
    }
}
