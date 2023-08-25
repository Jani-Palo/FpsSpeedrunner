using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace My.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreBoardEntry = 5;
        [SerializeField] private  Transform ScoreHolderTransform = null;
        [SerializeField] private GameObject scoreBoardEntryObject = null;

        [Header("Test")]
        [SerializeField] ScoreBoardEntryData testEntryData = new ScoreBoardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/scoreboard.json";

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
        
       }
        [ContextMenu("Add test entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }

        public void AddEntry(ScoreBoardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for(int i = 0; i < savedScores.ScoreBoard.Count; i++)
            {
                if(scoreboardEntryData.score > savedScores.ScoreBoard[i].score)
                {
                    savedScores.ScoreBoard.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.ScoreBoard.Count < maxScoreBoardEntry)
            {
                savedScores.ScoreBoard.Add(scoreboardEntryData);
            }

            if(savedScores.ScoreBoard.Count > maxScoreBoardEntry)
            {
                savedScores.ScoreBoard.RemoveRange(maxScoreBoardEntry, savedScores.ScoreBoard.Count - maxScoreBoardEntry);
            }
            UpdateUI(savedScores);

            SaveScores(savedScores);
        }
        private void UpdateUI(ScoreboardSaveData saveScores)
        {
            foreach(Transform child in ScoreHolderTransform)
            {
                Destroy(child.gameObject);
            }
            foreach(ScoreBoardEntryData Score in saveScores.ScoreBoard) 
            {
                Instantiate(scoreBoardEntryObject, ScoreHolderTransform).GetComponent<ScoreBoardEntryUi>().Initialise(Score);

            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if(!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using(StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();//String.IsNullOrEmpty(s)

                return JsonUtility.FromJson<ScoreboardSaveData>(json) != null ? JsonUtility.FromJson<ScoreboardSaveData>(json) : new ScoreboardSaveData();
            }
        }
        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using(StreamWriter stream  = new StreamWriter (SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}

