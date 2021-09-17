using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MazeGenerator
{
    public override void CreateCorridor()
    {
        for(int i = 1; i<=2;i++)
            CreateHorizontal();
        for(int i = 1; i <=3; i++)
        CreateVertical();

    }
    void CreateHorizontal()
    {
        bool over = false;

        int x = 1;
        int z = Random.Range(1, depth-1);

        while (!over)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) > 50)
            {
                x += Random.Range(0, 2);
            }
            else
            {
                z += Random.Range(-1, 2);
            }
            if (x < 1 || z < 1 || x >= width-1 || z >= depth-1)
            {
                over = !over;
            }
        }
    }
    void CreateVertical()
    {
        bool over = false;

        int x = Random.Range(1, width-1);
        int z = 1;

        while (!over)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) > 50)
            {
                x += Random.Range(-1, 2);
            }
            else
            {
                z += Random.Range(0, 2);
            }
            if (x < 1 || z < 1 || x >= width-1 || z >= depth-1)
            {
                over = !over;
            }
        }

    }
}
