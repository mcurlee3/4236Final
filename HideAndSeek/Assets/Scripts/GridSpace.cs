using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace
{
    [SerializeField]
    private float height;
    [SerializeField]
    private float width;
    private float cellSize;
    public float[,] GridArray;
    [SerializeField]
    //private Plane playArea;


    public GridSpace(float width, float height)
    {
        this.width = width;
        this.height = height;

        GridArray = new float[(int)width, (int)height];
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                
            }
        }

    }
    public void drawLine()
    {
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                Vector3 start = new Vector3(x, 1, y);
                Vector3 end = new Vector3(x, 1, y + 1);
                Debug.DrawLine(start, end, Color.white, 100f);
                start = new Vector3(x, 0, y);
                end = new Vector3(x + 1, 0, y);
                Debug.DrawLine(start, end, Color.white, 100f);
            }
        }
    }
}

