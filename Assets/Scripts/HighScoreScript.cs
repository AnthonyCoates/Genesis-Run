using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTXT;
    public TextMeshProUGUI highScoreTXT;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
    }

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        scoreTXT.text = "Score: " + scoreKeeper.GetScore();
        highScoreTXT.text = "High Score: " + scoreKeeper.GetHighScore();
    }
}
