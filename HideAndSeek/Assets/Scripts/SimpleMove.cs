using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody character; //character rb -- for positional purpose
    [SerializeField]
    float maxSpeed;
    public GameManager GM;
    private float speed; //this variable determines the character's actual movement speed
    Vector3 movementDirection;
    // Update is called once per frame

    private void Awake()
    {
        GM = GameManager._instance;
    }
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horiz, 0, vert);
        movementDirection.Normalize();
        //transform.Translate(movementDirection * maxSpeed * Time.deltaTime);

        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * maxSpeed * Time.deltaTime;
                
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.right * -maxSpeed * Time.deltaTime;
               
            }

            else if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * maxSpeed * Time.deltaTime;
                
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.forward * -maxSpeed * Time.deltaTime;
                
            }
            if (movementDirection != Vector3.zero)
            {
                transform.forward = movementDirection;
            }

        }

    }

    private void FixedUpdate()
    {

    }
}
