using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    private static int score = 0;
    private static int lives = 3;

    private int highScore;

    public int GetScore()
    {
        return score;
    }

    public int GetLives()
    {
        return lives;
    }

    public void AdjustScore(int a)
    {
        score += a;
    }

    public void AdjustLives(int a)
    {
        lives += a;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void SetHighScore(int hs)
    {
        if (hs > highScore)
        {
            highScore = hs;

            PlayerPrefs.SetInt("HighScore", highScore);
        }

        PlayerPrefs.Save();
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        if (FindObjectsOfType<ScoreKeeper>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        highScore = PlayerPrefs.GetInt("HighScore");

        Debug.Log(PlayerPrefs.HasKey("HighScore"));
    }

    private void Update()
    {
        CheckLives();
    }

    public void StartGame()
    {
        score = 0;
        lives = 3;

        SceneManager.LoadScene(1);
    }

    private void CheckLives()
    {
        if (lives < 1)
        {
            SceneManager.LoadScene(2);

            SetHighScore(score);

            lives = 3;
        }
    }
}
