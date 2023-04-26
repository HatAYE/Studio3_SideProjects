using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Node :IComparable
{
    int gcost, hcost, fcost;
    Text gcostText, hcostText, fcostText, gridPositionText;
    Vector3 worldPosition;
    Vector3Int gridPosition;
    GameObject mesh;
    public Node parent;
    public int version;
    public bool blocked;
    public Bounds bounds;
    public Vector3 WorldPosition
    {
        get { return worldPosition; }
        private set
        {

        }
    }
    public Vector3Int GridPosition
    {
        get { return gridPosition; }
        private set
        {

        }
    }
    public int Fcost
    {
        get { return gcost + hcost; }
        set
        {
            if (blocked==true)
            {
                fcost = int.MaxValue;
            }
        }
    }
    public int Hcost
    {
        get
        {
            return hcost;
        }
        set
        {
            hcost = value;

            hcostText.text= value.ToString();
            fcost = gcost + hcost;
            fcostText.text= fcost.ToString();
        }
    }
    public int Gcost
    {
        get
        {
            return gcost;
        }
        set
        {
            gcost = value;
            gcostText.text = value.ToString();
            fcost = gcost + hcost;
            fcostText.text = fcost.ToString();
        }
    }
    public GameObject Mesh
    {
        get
        {
            return mesh;
        }

        set
        {
            mesh = value;
            gcostText=mesh.transform.GetChild(0).GetChild(0).GetComponent<Text>();
            hcostText=mesh.transform.GetChild(0).GetChild(1).GetComponent<Text>();
            fcostText=mesh.transform.GetChild(0).GetChild(2).GetComponent<Text>();
            gridPositionText = mesh.transform.GetChild(0).GetChild(3).GetComponent<Text>();
            gridPositionText.text = gridPosition.ToString();
        }
    }
    public Node( Vector3Int gp , Vector3 wp)
    {
        worldPosition = wp;
        gridPosition = gp;
        //this.blocked = blocked;
    }

    public int CompareTo(object obj)
    {
        Node otherNode= (Node) obj;
        if(fcost<otherNode.fcost)
        {
            return -1;
        }
        else if (fcost> otherNode.fcost)
        {
            return 1;
        }
        return 0;
    }
}  
