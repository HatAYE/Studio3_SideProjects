using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCollisionDetection : MonoBehaviour
{
    void Start()
    {
        
    }

    public Node[] nodes;

    void OnTriggerStay(Collider other)
    {
        foreach (Node node in nodes)
        {
            if (other.bounds.Intersects(node.bounds))
            {
                node.blocked = true;
            }
        }
    }
}
