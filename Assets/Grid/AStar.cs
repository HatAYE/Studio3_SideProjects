using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AStar : MonoBehaviour
{
    public Vector3Int startNodePosition = new Vector3Int(0, 0, 0);
    public Vector3Int goalNodePosition = new Vector3Int(2, 0, 2);
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();
    List<Node> neighbors = new List<Node>();
    List<Node> retracedPathNode= new List<Node>();
    Node currentNode;
    Node goalNode;
    Node startNode;
    bool foundThePath;
    int algorithemVersion;
    [SerializeField] Grid grid;

    private void Start()
    {
        startNode = grid.GetNode(startNodePosition);
        startNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.blue;

        goalNode = grid.GetNode(goalNodePosition);
        goalNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.magenta; 

        openList.Add(startNode);
        grid = GetComponent<Grid>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartingAlgorithm(new Vector3Int(2, 0, 2), new Vector3Int(5, 0, 3));
        AStarPathfinding();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RestartingAlgorithm(new Vector3Int(7, 0, 3), new Vector3Int(1, 0, 4));
            AStarPathfinding();

        }

    }
    void AStarPathfinding()
    {
        while (true && !foundThePath)
        {
            algorithemVersion++;
            openList.Sort();
            currentNode = openList[0];
            currentNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.gray;
            openList.RemoveAt(0);
            closedList.Add(currentNode);
            neighbors.Clear();

            #region Neighbors
            if (currentNode.GridPosition.x + 1 < grid.gridCellCountx)
            {
                Node rightNode = grid.GetNode(currentNode.GridPosition + new Vector3Int(1, 0, 0));
                rightNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.green;
                neighbors.Add(rightNode);
            }

            if (currentNode.GridPosition.x - 1 >= 0)
            {
                Node leftNode = grid.GetNode(currentNode.GridPosition + new Vector3Int(-1, 0, 0));
                leftNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.green;
                neighbors.Add(leftNode);
            }
            if (currentNode.GridPosition.z + 1 < grid.gridCellCountz)
            {
                Node upNode = grid.GetNode(currentNode.GridPosition + new Vector3Int(0, 0, 1));
                upNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.green;
                neighbors.Add(upNode);
            }

            if (currentNode.GridPosition.z - 1 >= 0)
            {
                Node downNode = grid.GetNode(currentNode.GridPosition + new Vector3Int(0, 0, -1));
                downNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.green;
                neighbors.Add(downNode);
            }
            #endregion

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (closedList.Contains(neighbors[i]))
                {
                    continue;
                }

                int newMovementCost = CalculateDistance(neighbors[i].GridPosition, currentNode.GridPosition) + currentNode.Gcost;
                if (newMovementCost < neighbors[i].Gcost || !openList.Contains(neighbors[i]) || neighbors[i].Gcost <= 0)
                {

                    if (!openList.Contains(neighbors[i]) && !closedList.Contains(neighbors[i]))
                    {
                        if (neighbors[i].version < algorithemVersion)
                        {
                            neighbors[i].parent = null;
                            neighbors[i].version = algorithemVersion;
                        }
                        openList.Add(neighbors[i]);
                        neighbors[i].Gcost = newMovementCost;
                        neighbors[i].Hcost = CalculateDistance(neighbors[i].GridPosition, goalNode.GridPosition);
                        neighbors[i].parent = currentNode;
                    }
                    Debug.Log("gCost" + neighbors[i].Gcost);
                }
                if (currentNode == goalNode)
                {
                    foundThePath = true;
                    neighbors[i].parent = currentNode;
                    RetracePath(currentNode);
                    retracedPathNode.Reverse();


                    for (int j = 0; j < retracedPathNode.Count; j++)
                    {
                        retracedPathNode[j].Mesh.GetComponent<MeshRenderer>().material.color = Color.cyan;

                    }
                    return;
                }

            }

        }
    }

    public int CalculateDistance(Vector3Int position, Vector3Int destination)
    {
        return Mathf.Abs(destination.x - position.x) + Mathf.Abs(destination.y - position.y) + Mathf.Abs(destination.z - position.z);
    }

    void RestartingAlgorithm(Vector3Int startPos, Vector3Int goalPos)
    {
        grid.ClearGrid();
        openList.Clear();
        closedList.Clear();
        neighbors.Clear();
        retracedPathNode.Clear();
        foundThePath = false;

        startNode.Gcost= 0;
        startNode.Hcost = 0;
        startNode.parent = null;

        goalNode.Gcost = 0;
        goalNode.Hcost = 0;
        goalNode.parent = null;

        startNode = grid.GetNode(startNodePosition);
        startNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.blue;
        goalNode = grid.GetNode(goalNodePosition);
        goalNode.Mesh.GetComponent<MeshRenderer>().material.color = Color.magenta;
        openList.Add(startNode);
        startNodePosition= startPos;
        goalNodePosition= goalPos;
        AStarPathfinding();
    }

    void RetracePath(Node node)
    {
         retracedPathNode.Add(node);
        if (node.parent!=null)
        {
            //retracedPathNode.Add(node.parent);
            //node= node.parent;
            RetracePath(node.parent);
        }
    }

}
