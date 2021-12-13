using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    private int Score = 0;
    private int Lives = 3;

    private int scene;
    public Text ScoreText;
    public Text LifeText;
    //[SerializeField]
    //private GameObject player;

    //[SerializeField]
    //private GameObject platform;
    public GameObject playUI;
    public GameObject menu;
    //singleton pattern
    static public GameManager Instance { get { return _instance; } }
    static public GameManager _instance;

    public void Awake()
    {
        _instance = this;
        playUI.SetActive(false);

    }

    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        ScoreText.text = "Score: " + Score;
        LifeText.text = "Lives: " + Lives;
        if(Lives < 0)
        {
            playUI.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }




    public void IncrementScore()
    {
       Score++;     
    }
    public void DecrementScore()
    {
        Score--;
    }
    public void DecrementLives()
    {
        Lives--;
        if(Lives < 0)
        {
            playUI.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }
    public int GetScore()
    {
        return this.Score;
    }
 

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playUI.SetActive(true);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void RestartGame()
    {
        playUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame()
    {
        Application.Quit();
    }


} 
