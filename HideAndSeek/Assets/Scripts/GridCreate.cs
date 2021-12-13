using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{
    [SerializeField]
    public float width;
    [SerializeField]
    public float height;
    public GridSpace gridSpace;
    // Start is called before the first frame update
    void Start()
    {
        gridSpace = new GridSpace(width, height);
    }
    private void Update()
    {
        gridSpace.drawLine();
    }
}
