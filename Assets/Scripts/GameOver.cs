using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel; // پنل Game Over از داخل Inspector تنظیم میشه
    public Text gameOverText;        // متن Game Over (اختیاری برای ویرایش متن)

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // مخفی کردن پنل در شروع
    }

    public void ShowGameOver(string message = "Game Over!")
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.text = message;
        }

        Time.timeScale = 0; // متوقف کردن بازی
    }
}
