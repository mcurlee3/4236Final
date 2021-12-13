using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar: MonoBehaviour
{
    Grid grid;
    public Transform StartPos;
    public Transform TargetPos;
    public GameObject GM;

    private void Awake()
    {
        StartPos = this.transform;
        grid = GM.GetComponent<Grid>();
    }

    private void Update()
    {
        FindPath(StartPos.position, TargetPos.position);
    }

    void FindPath(Vector3 _StartPos, Vector3 _TargetPos)
    {
        Node StartNode = grid.NodeFromWorldPosition(_StartPos);
        Node TargetNode = grid.NodeFromWorldPosition(_TargetPos);

        List<Node> OpenList = new List<Node>();
        List<Node> ClosedList = new List<Node>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Node current = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if(OpenList[i].FCost < current.FCost || OpenList[i].FCost == current.FCost && OpenList[i].hCost < current.hCost)
                {
                    current = OpenList[i];
                }
                OpenList.Remove(current);
                ClosedList.Add(current);

                if(current == TargetNode)
                {
                    GetFinalPath(StartNode, TargetNode);
                    break;
                }

                foreach(Node Neighbor in grid.GetNeighbor(current))
                {
                    if(!Neighbor.isBound || ClosedList.Contains(Neighbor))
                    {
                        continue;
                    }
                    int MoveCost = current.gCost + GetManhattanDis(current, Neighbor);

                    if(MoveCost < Neighbor.gCost  || !OpenList.Contains(Neighbor))
                    {
                        Neighbor.gCost = MoveCost;
                        Neighbor.hCost = GetManhattanDis(Neighbor, TargetNode);
                        Neighbor.parent = current;

                        if (!OpenList.Contains(Neighbor))
                        {
                            OpenList.Add(Neighbor);
                        }
                    }
                }
                
            }
        }
    }

    void GetFinalPath(Node _StartNode, Node _TargetNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node Current = _TargetNode;

        while(Current != _StartNode)
        {
            FinalPath.Add(Current);
            Current = Current.parent;
        }

        FinalPath.Reverse();
        grid.Path = FinalPath;
    }

    int GetManhattanDis(Node _current, Node _target)
    {
        int xx = Mathf.Abs(_current.gridX - _target.gridX);
        int yy = Mathf.Abs(_current.gridY - _target.gridY);

        return xx + yy;
    }
}
