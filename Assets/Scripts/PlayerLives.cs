using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public float respawnDelay = 2f;

    public GameObject gameOverPanel;      // پنل Game Over
    public TMP_Text gameOverText;         // متن داخل پنل

    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // مخفی کردن پنل در شروع
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            HandleHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Projectile"))
        {
            Destroy(collision.gameObject);
            HandleHit();
        }
    }

    private void HandleHit()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            spriteRenderer.enabled = false;
            playerCollider.enabled = false;
            Invoke(nameof(Respawn), respawnDelay);
        }
    }

    private void Respawn()
    {
        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = (i < lives);
        }
    }

    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (gameOverText != null)
            {
                gameOverText.text = "Game Over";
            }
        }

        Time.timeScale = 0f; // توقف بازی
        Destroy(gameObject);
    }
}
