using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace My.Scoreboards
{
    public class ScoreBoardEntryUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(ScoreBoardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.name;
            entryScoreText.text = scoreboardEntryData.score.ToString();
        }
    }
}

