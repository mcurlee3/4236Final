using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform StartPosition;
    public LayerMask BoundaryMask = 7;
    public Vector2 gridWorldSpace;

    public float nodeSize;
    public float distance;

    Node[,] gridArray;
    public List<Node> Path;

    float Diameter;
    int gridSizeX, gridSizeY;

    public void Start()
    {
        Diameter = nodeSize * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSpace.x / Diameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSpace.y / Diameter);

        GridCreate();
    }

    void GridCreate()
    {
        gridArray = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSpace.x / 2 - Vector3.forward * gridWorldSpace.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * Diameter + nodeSize) + Vector3.forward * (y * Diameter + nodeSize);
                bool Boundary = true;
                if (Physics.CheckSphere(worldPoint, nodeSize, BoundaryMask))
                {
                    Boundary = true;
                }
                else if (Physics.CheckSphere(worldPoint, nodeSize, 8))
                {
                    Boundary = false;
                }

                gridArray[x, y] = new Node(Boundary, worldPoint, x, y);
            }
        }
    }

    //Calculates Neighbors for a node
    public List<Node> GetNeighbor(Node _current)
    {
        List<Node> Neighbors = new List<Node>();

        int xCheck;
        int yCheck;

        //right side check
        xCheck = _current.gridX + 1;
        yCheck = _current.gridY;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                Neighbors.Add(gridArray[xCheck, yCheck]);
            }
        }

        //left side check
        xCheck = _current.gridX - 1;
        yCheck = _current.gridY;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                Neighbors.Add(gridArray[xCheck, yCheck]);
            }
        }

        //bottom side check
        xCheck = _current.gridX;
        yCheck = _current.gridY - 1;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                Neighbors.Add(gridArray[xCheck, yCheck]);
            }
        }

        //top side check
        xCheck = _current.gridX;
        yCheck = _current.gridY + 1;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                Neighbors.Add(gridArray[xCheck, yCheck]);
            }
        }
        return Neighbors;
    }

    //Takes a position in worldspace and returns the relevant Node
    public Node NodeFromWorldPosition(Vector3 _WorldPos)
    {
        float xPoint = ((_WorldPos.x + gridWorldSpace.x / 2) / gridWorldSpace.x);
        float yPoint = ((_WorldPos.y + gridWorldSpace.y / 2) / gridWorldSpace.y);

        //this is for if the target (player) left the play area
        xPoint = Mathf.Clamp01(xPoint);
        yPoint = Mathf.Clamp01(yPoint);

        //calculate position in Node array
        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);

        return gridArray[x, y];
    }

    //draws the grid on the screen
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSpace.x, 1, gridWorldSpace.y));

        if (gridArray != null)
        {
            foreach (Node node in gridArray)
            {
                if (node.isBound)
                {
                    Gizmos.color = Color.yellow;
                }
                else
                {
                    Gizmos.color = Color.blue;
                }

                if (Path != null)
                {
                    Gizmos.color = Color.red;
                }

                //Gizmos.DrawCube(node.position, Vector3.one * (Diameter - distance));
            }
        }
    }

}
