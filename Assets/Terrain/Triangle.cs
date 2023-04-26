using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    MeshFilter filter;
    MeshRenderer meshRenderer;

    [SerializeField] int Xrectangles;
    [SerializeField] int Zrectangles;
    [SerializeField] Texture2D heightMap;
    [SerializeField] int height;

    int Xvertices;
    int Zvertices;
    int totalVertices;
    Vector3[] vertices;

    int[] indecies;
    int totalIndecies;


    void Start()
    {
        #region setting up variables
        filter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material.color = Color.black;
        #endregion

        //int widthRatio = heightMap.width / Xvertices;
        //int heightRatio = heightMap.height / Zvertices;



        //---------MAKING THE GRID-----------
        //---------CALCULATING VERTICES THROUGH THENUMBER OF RECTANGLES-----------
        Xvertices = Xrectangles + 1; //every triangle will have 2 vertices on each axis. 1 triangle= 2 vertices.
        Zvertices = Zrectangles + 1;
        totalVertices = Xvertices * Zvertices;
        vertices = new Vector3[totalVertices];
        for (int z = 0; z < Zvertices; z++)
        {
            for (int x = 0; x < Xvertices; x++)
            {
                Color pixel = heightMap.GetPixel(x, z);
                int index = x + z * Xvertices;
                vertices[index] = new Vector3(x, pixel.r * height, -z);
            }
        }

        //--------- MAKING THE TRIANGLES/ INDECIES--------
        totalIndecies = Xrectangles * Zrectangles * 6; //6 is the number for how many vertices there will be in a swquare
        indecies = new int[totalIndecies];
        int currentIndex = 0;
        int p = 0;
        for (int z = 0; z < Zrectangles; z++)
        {

            for (int x = 0; x < Xrectangles; x++)
            {
                indecies[p + 0] = currentIndex;
                indecies[p + 1] = currentIndex + 1;
                indecies[p + 2] = currentIndex + Xvertices + 1;
                indecies[p + 3] = currentIndex + Xvertices + 1;
                indecies[p + 4] = currentIndex + Xvertices;
                indecies[p + 5] = currentIndex;
                currentIndex++;
                p += 6;
                /*if (currentIndex == Xvertices *currentRow -1)
                {
                    currentIndex++;
                    currentRow++;
                }*/

            }
            currentIndex++;
        }

        //--------VISUALIZATIONS----------
        filter.mesh.vertices = vertices;
        filter.mesh.triangles = indecies;


        /*filter.mesh.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
                new Vector3(1,0,0),
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 1),

        };
        filter.mesh.triangles = new int[]
        {
            0,1,2,1,3,2
        };*/




    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }

    }

    void Update()
    {

    }
}
