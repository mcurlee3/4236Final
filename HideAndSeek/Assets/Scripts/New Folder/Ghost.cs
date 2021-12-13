using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ghost : MonoBehaviour
{
    public GameManager GM;
    public float speed = 10;
    public GameObject target;
    Vector3 lookRotation;
    Quaternion playerRotation;
    private Vector3 targetPos;
    float obstacleBumpSeed = 0.01f;
    Collision col;

    public void Awake()
    {
        GM = GameManager._instance;
    }

    public void Update()
    {
        targetPos = target.transform.position;
        //seekTarget();
        Vector3 destination =
        transform.position = Vector3.MoveTowards(transform.position, targetPos,
            speed * Time.deltaTime);
        lookRotation = new Vector3(targetPos.x - transform.position.x,
            transform.position.y - 0, targetPos.z - transform.position.z);
        playerRotation = Quaternion.LookRotation(lookRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation,
           1.0f * Time.deltaTime);
    }

    void seekTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos,
        speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Obstacle")
        {

            col = collision;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {
            return;
        }
            
        if (collision.gameObject.tag == "Friendly")
        {
            SceneManager.LoadScene("Level 256");
            GM.DecrementLives();
        }
            // Calcualte vector from player to obstacle
        Vector3 toObstacle = collision.gameObject.transform.position -
        transform.position;
        toObstacle.Normalize();
        toObstacle.y = 0f;

        float dotr = Vector3.Dot(transform.right, toObstacle);
        float dott = Vector3.Dot(transform.forward, toObstacle);
        // Obstacle is on the left of the obstacle -> push player right
        if (dotr< 0f)
        {
            transform.position += transform.right * 5*obstacleBumpSeed;
        }
        else
        {
            transform.position += transform.right * -5f * obstacleBumpSeed;
        }
        if (dott < 0f)
        {
            transform.position += transform.forward * 5*obstacleBumpSeed;
        }
        else
        {
            transform.position += transform.forward * -5f * obstacleBumpSeed;
        }
    }
}
