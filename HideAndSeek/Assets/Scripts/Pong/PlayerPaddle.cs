using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector3 moveDir;
    Vector3 movementDirection;
    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horiz, 0, vert);

        movementDirection.Normalize();
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -Vector3.right * this.speed * Time.deltaTime;
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if(moveDir.sqrMagnitude != 0)
        {
            paddle.AddForce(moveDir * this.speed);
        }
    }
}
