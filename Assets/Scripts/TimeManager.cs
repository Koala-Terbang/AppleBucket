using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    private float timer = 60f;
    private int score = 0;
    private bool isGameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                EndGame();
            }
            UpdateUI();
        }
    }

    public void StartGame()
    {
        timer = 60f;
        score = 0;
        isGameRunning = true;
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    private void EndGame()
    {
        isGameRunning = false;
        FindObjectOfType<RetryScreen>().ShowRetryScreen(score);
    }

    private void UpdateUI()
    {
        timerText.text = $"{timer:F1}";
        scoreText.text = $"Score: {score}";
    }
}
