using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryScreen : MonoBehaviour
{
    public GameObject retryScreenUI;
    public Text finalScoreText;
    public GameObject MainMenuUI;

    public void ShowRetryScreen(int finalScore)
    {
        retryScreenUI.SetActive(true);
        finalScoreText.text = $"Score: {finalScore}";
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        FindObjectOfType<TimeManager>().StartGame();
        retryScreenUI.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 0f;
        MainMenuUI.SetActive(true);
        retryScreenUI.SetActive(false); 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
