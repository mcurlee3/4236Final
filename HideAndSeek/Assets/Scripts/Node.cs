using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int gridX;
    public int gridY;

    public bool isBound;
    public Vector3 position;

    public Node parent;

    public int gCost;
    public int hCost;

    public int FCost { get { return gCost + hCost; } }

    public Node(bool _isBound, Vector3 _position, int _gridX, int _gridY)
    {
        isBound = _isBound;
        position = _position;
        gridX = _gridX;
        gridY = _gridY;
    }

}
