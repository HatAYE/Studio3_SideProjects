using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BTNode 
{
       float idleTimer = 8f;

    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            idleTimer = 8;
            executed = true;
        }
        
        while( idleTimer >= 0 )
        {
            idleTimer -= Time.deltaTime;
            Debug.Log("Idling...");
        }
        Debug.Log("Idling successful :D");
        return States.Success;
        /*if (idleTimer <= 0 )
        {
            Debug.Log("Idling successful :D");
            return States.Success;
        }*/    }

}

public class Wandering : BTNode
{
        float wanderTimer = 3f;

    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            wanderTimer = 3f;
            executed = true;
        }
        while (wanderTimer >= 0 )
        {
            wanderTimer -= Time.deltaTime;
            Debug.Log("wandering...");
        }
        Debug.Log("Robot is wandering was successful");
        return States.Success;

    }
}

public class ScanningForTrash : BTNode
{
        float scanningTimer = 5f;
    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            scanningTimer = 5f;
            executed = true;
        }
        while ( scanningTimer > 0 )
        {
            scanningTimer -= Time.deltaTime;
            Debug.Log("Robot is scanning for trash");
        }
        Debug.Log("Scanning was successful");
        return States.Success;

    }
}

public class TrashIsSolid: BTNode
{
    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            executed = true;
        }
        System.Random random = new System.Random();
        int trashType = random.Next(1, 20);
        if (trashType % 2 == 0)
        {
            Debug.Log("Trash was SOLID! picking it up right now. (trash probability was "+ trashType);
            return States.Success;
        }
        Debug.Log("Trash was not SOLID! (trash probability was " + trashType);
        return States.Failure;
    }
}
public class TrashIsLiquid : BTNode
{
    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            executed = true;
        }
        System.Random random = new System.Random();
        int trashType = random.Next(1, 20);
        if (trashType % 2 != 0)
        {
            Debug.Log("Trash was LIQUID! mopping it right now. (trash probability was " + trashType);
            return States.Success;
        }
        Debug.Log("Trash was not LIQUID!(trash probability was " + trashType);
        return States.Failure;
    }
}

public class ThrowingOutTrash : BTNode
{
    public override States Execute()
    {
        if (executed)
        {
            return States.Running;
        }
        if (!executed)
        {
            executed = true;
        }
        System.Random random = new System.Random();
        int foundTrashCan = random.Next(1, 10);
        if (foundTrashCan % 2 == 0)
        {
            Debug.Log("Found trash can ,trash escorted successfully!! :D");
            return States.Success;
        }

        Debug.Log("Didn't find a trash can, Mission failed :(");
        return States.Failure;
    }
}