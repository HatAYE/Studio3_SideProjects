using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree1 : MonoBehaviour
{
    RepeaterNode root = new RepeaterNode(); //this node starts the behaviour tree
    SequenceNode sequence = new SequenceNode();
    SelectorNode scanningSelector = new SelectorNode();
    void Start()
    {
        // Create all the nodes
        BTNode IdleNode = new Idle();
        BTNode WanderNode = new Wandering();
        BTNode ScanningNode = new ScanningForTrash();
        BTNode trashIsSolidNode = new TrashIsSolid();
        BTNode trashIsLiquidNode = new TrashIsLiquid();
        BTNode throwingTheTrashOutNode = new ThrowingOutTrash();


        scanningSelector.AddChildren(trashIsSolidNode);
        scanningSelector.AddChildren(trashIsLiquidNode);


        root.AddChildren(sequence);
        sequence.AddChildren(IdleNode);
        sequence.AddChildren(WanderNode);
        sequence.AddChildren(ScanningNode);
        sequence.AddChildren(scanningSelector);
        sequence.AddChildren(throwingTheTrashOutNode);
    }

    void Update()
    {
        if (!root.executed)
        {
            root.Execute();
        }
    }
}
