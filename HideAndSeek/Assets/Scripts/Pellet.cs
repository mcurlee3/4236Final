using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public GameManager GM;

    private void Awake()
    {
        GM = GameManager._instance;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GM.IncrementScore();
        }
    }
}
