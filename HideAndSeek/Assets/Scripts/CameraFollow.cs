using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [SerializeField]
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 offsetpos = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, offsetpos, smoothSpeed);
        transform.position = smoothed;
    }
}
