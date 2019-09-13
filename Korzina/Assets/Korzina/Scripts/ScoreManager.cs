using System;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    //EVENTS

    public event Action<int, int> OnUpdateScoreEvent;

    //PUBLIC BARIABLES

    public int Score { get; private set; } = 0;
    public int BestScore { get; private set; }

    //CONSTANTS

    public const string SCORE_KEY = "Score";
    public const string BEST_SCORE_KEY = "Best_Score";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(BEST_SCORE_KEY))
        {
            BestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);
        }
        else
        {
            Score = 0;
            BestScore = 0;
        }
    }

    public void AddScore()
    {
        Score++;
        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt(BEST_SCORE_KEY, BestScore);
        }
        OnUpdateScoreEvent?.Invoke(Score, BestScore);
    }

    public void ResetScore()
    {
        Score = 0;
        OnUpdateScoreEvent?.Invoke(Score, BestScore);
    }
}