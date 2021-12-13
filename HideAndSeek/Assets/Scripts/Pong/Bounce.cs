using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bounce : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    public GameManager GM;
    private Rigidbody rb;
    private Transform tr;
    public float sSpeed = 75;
    public AIPaddle AI;
    public int score;
    private void Awake()
    {
        GM = GameManager._instance; // Assign the `gameManager` variable by using the static reference
        AI = AIPaddle._instance;
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AddForce();
    }

    private void AddForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector3 sDirection = new Vector3(x, 0, z);
        rb.AddForce(sDirection * sSpeed, ForceMode.Force);
        rb.velocity = sDirection*sSpeed;
    }
    private void Update()
    {
        score = GM.GetScore();
        if (rb.velocity.magnitude < sSpeed)
        {
            rb.velocity = rb.velocity * 1.1f;
        }
        else
        {
            sSpeed += 0.001f;
            if(sSpeed > 18.0f)
            {
                sSpeed -= 0.001f;
            }


        }


    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Pong");
            Destroy(gameObject);
            GameObject ball = Instantiate(Ball);
            sSpeed = 5.0f;
            AIPaddle.ball = ball.GetComponent<Rigidbody>();
            GM.DecrementScore();
            GM.DecrementLives();
        }
        if (collision.gameObject.tag == "Friendly")
        {
            SceneManager.LoadScene("Pong");
            Destroy(gameObject);
            GameObject ball = Instantiate(Ball);
            sSpeed = 5.0f;
            AIPaddle.ball = ball.GetComponent<Rigidbody>();
            GM.IncrementScore();
         
        }
    }
}
