using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject cube;
    public int depth = 30;
    public int width = 30;
    public byte[,] map;
    // Start is called before the first frame update
    void Start()
    {
        InitializeMap();
        CreateCorridor();
        GenerateMap();
    }

    void InitializeMap()
    {
        map = new byte[width, depth];
        for(int z = 0; z < depth; z ++)
            for (int x = 0; x < width; x ++)
            {
                map[x, z] = 1;
            }
    }

    void GenerateMap()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.position = pos;
                }
            }
    }

    public virtual void CreateCorridor()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
