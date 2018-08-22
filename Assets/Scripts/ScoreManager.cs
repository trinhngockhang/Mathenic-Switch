using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    private const string HighScore = "High Score";
    private void Awake()
    {
        _MakeSingleInstance();
        _IsGameStartedForTheFirstTime();
    }

    void _IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("_IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HighScore, 0);
            PlayerPrefs.SetInt("_IsGameStartedForTheFirstTime", 0);
        }
    }

    void _MakeSingleInstance()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScore, score);
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);
    }
}