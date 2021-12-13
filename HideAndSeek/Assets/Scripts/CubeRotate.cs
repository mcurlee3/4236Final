using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    [SerializeField]
    float rotSpd = .005f;
    [SerializeField]
    GameObject block;


    private void Start()
    {
        block.name = "Self";
    }
    // Update is called once per frame
    void Update()
    {
        //rotSpd += .005f;
        //block.transform += block.transform.Rotate(rotSpd,0,0, Space.Self);
        Vector3 rotationToAdd = new Vector3(rotSpd, 0, 0);
        transform.Rotate(rotationToAdd);
    }
}
