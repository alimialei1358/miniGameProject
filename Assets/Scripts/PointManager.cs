using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject youWinPanel; // از Inspector تنظیم می‌کنی

    void Start()
    {
        if (youWinPanel != null)
        {
            youWinPanel.SetActive(false); // مخفی کردن پنل در شروع بازی
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

        if (score >= 750)
        {
            GameWin();
        }
    }

void GameWin()
{
    Debug.Log("GameWin called");

        youWinPanel.SetActive(true);


    Time.timeScale = 0;
}

}
