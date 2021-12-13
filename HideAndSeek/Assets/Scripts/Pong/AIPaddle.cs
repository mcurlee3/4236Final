using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    [SerializeField]
    public Rigidbody b2;
    public GameManager GM;
    public static Rigidbody ball;
    public Vector3 moveDirection;
    public int score;
    [SerializeField]
    public int pongScore = 2;
    static public AIPaddle Instance { get { return _instance; } }
    public static AIPaddle _instance;
    public void Awake()
    {
        GM = GameManager._instance;
        ball = b2;
        _instance = this;
    }

    private void Update()
    {
        score = GM.GetScore();
        if(score > pongScore)
        {
            GM.NextScene();
        }
        if(ball.velocity.z > 0.0f && ball.position.z > 0)
        {
            if(ball.position.x > this.transform.position.x)
            {
                transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
            else if(ball.position.x < this.transform.position.x)
            {
                transform.position += -Vector3.right * this.speed * Time.deltaTime;
            }
            else
            {
                moveDirection = Vector3.zero;
            }

        }
    }
    private void FixedUpdate()
    {
        
        if (moveDirection.sqrMagnitude != 0)
        {
            paddle.AddForce(moveDirection * this.speed);
        }
    }
    public void increaseSpeed()
    {
        speed += 0.2f;
    }
}
