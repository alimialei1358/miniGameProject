using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreenPanel;

    void Start()
    {
        if (startScreenPanel != null)
        {
            startScreenPanel.SetActive(true);
        }

        Time.timeScale = 0f; // توقف بازی در ابتدا
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        if (startScreenPanel != null)
        {
            startScreenPanel.SetActive(false);
        }

        Time.timeScale = 1f; // ادامه بازی
    }
}
