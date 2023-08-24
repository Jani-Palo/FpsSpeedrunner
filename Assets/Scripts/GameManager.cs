using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int Score;
    public static GameManager instance;
    [SerializeField] private GameObject player;

    public Text ScoreText;

    UiManager uiManager;
    public void IncrementScore(int score)
    {
        Score+= score;
        ScoreText.text = "Score: " + Score + "/10";
    }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Score == 10)
        {
            loadNextLevel();
        }
    }
    public void loadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       uiManager.UpdateTimerUI();
    }
   
}
