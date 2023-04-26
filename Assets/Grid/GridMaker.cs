using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] GameObject platforms;
    List<GameObject> platformsList = new List<GameObject>();
    void Start()
    {
        FormingTheGrid();
    }

    void FormingTheGrid()
    {
        for (int x =0 ; x < width; x++)
        {
            for ( int z=0 ; z < height ; z++)
            {
                GameObject PLATFORM= Instantiate (platforms, new Vector3 (x  , 0, z ), Quaternion.identity);
                platformsList.Add (PLATFORM);
                PLATFORM.name = "smurFEET";
            }
        }
    }
    private void OnDrawGizmos()
    {        
        Gizmos.color = Color.magenta;
        for (int x = 0 ;x < platformsList.Count; x++)
        {
            Gizmos.DrawWireCube(platformsList[x].transform.position, new Vector3 (1,0.2f,1));
        }
    }
}
