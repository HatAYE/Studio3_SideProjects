using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Node[] nodes;
    public int gridCellCount, gridCellCountx, gridCellCountz;
    public Vector3  cellSize;
    public GameObject nodePrefab;
    
    void Start()
    {
        gridCellCount = gridCellCountx * gridCellCountz;
        nodes= new Node[gridCellCount];

        for (int z=0; z<gridCellCountz; z++)
        {
            for (int x=0; x<gridCellCountx; x++)
            {
                int index = x + z * gridCellCountx;

                //bool walkable = !(Physics.CheckSphere(nodes[index].WorldPosition, cellSize.x* cellSize.z));
                nodes[index] = new Node (new Vector3Int(x, 0, z), new Vector3 (x * cellSize.x, 0, z * cellSize.z));
                nodes[index].Mesh = Instantiate(nodePrefab, nodes[index].WorldPosition, Quaternion.identity);
                nodes[index].Mesh.transform.position = nodes[index].WorldPosition;
                nodes[index].Mesh.transform.localScale = cellSize;
            }
        }
    }

    public Node GetNode(Vector3Int gridPosition)  
    {
        int index=  gridPosition.x + gridPosition.z * gridCellCountx;
        return nodes[index]; 
    }
    public void ClearGrid()
    {
        for (int i=0; i<nodes.Length; i++)
        {
            nodes[i].Mesh.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
