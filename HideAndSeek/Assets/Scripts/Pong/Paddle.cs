using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody paddle;
    public float speed = 5.0f;
    private void Awake()
    {
        paddle = GetComponent<Rigidbody>();
    }
}
