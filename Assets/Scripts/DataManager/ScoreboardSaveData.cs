using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace My.Scoreboards
{
    [Serializable]
    public class ScoreboardSaveData
    {
        public List<ScoreBoardEntryData> ScoreBoard = new List<ScoreBoardEntryData>();
    }
}

