using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    
    private int score;
    public float timeRemaining;
    public bool timeIsRunning;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timeRemaining = 10f;
        timeIsRunning = true;
        scoreText.text = "Score: " + 0;
        timerText.text = "Time: " + 10;
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;
    }

    public IEnumerator StartTimer()
    {
        while (timeIsRunning)
        {
            yield return new WaitForSeconds(1);
            timeRemaining -= 1;
            timerText.text = "Time: " + timeRemaining;
            if (timeRemaining < 0)
            {
                timeIsRunning = false;
                timerText.text = "Time: " + 0;
                Debug.Log("Game Over");
            }
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
