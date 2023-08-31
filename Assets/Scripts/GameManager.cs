using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public int Score;
    public static GameManager instance;
    [SerializeField] private GameObject player;


    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    public float speed = 10f;
  
    public TMP_Text ScoreText;
    
    public void IncrementScore(int score)
    {
        Score+= score;
        ScoreText.text = "Gems Collected: " + Score + "/7";
        if (Score >= 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        
        RestartRun();
    }
   
    public void RestartRun()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }
}
   

