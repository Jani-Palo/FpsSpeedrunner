using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Coins")]
public class PlayerData : ScriptableObject
{
    public int score;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        score = gameManager.GetComponent<GameManager>().Score;
    }
}
