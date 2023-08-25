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

    public TMP_Text timerText;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    public float speed = 10f;
  
    public TMP_Text ScoreText;
    
    public void IncrementScore(int score)
    {
        Score+= score;
        ScoreText.text = "Score: " + Score ;

    }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        UpdateTimerUI();
        RestartRun();
    }
    public void loadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + "m" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
    public void RestartRun()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}
   

