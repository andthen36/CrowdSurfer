using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;
    public int score = 0;
    public float timeLeft = 60.0f; // 60 seconds for the countdown
    public Text scoreText; // Assign in inspector
    public Text timerText; // Assign in inspector
void Awake()
    {
        // Assign the instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep this object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Ensures there is only one instance
        }
    }
    void Update()
    {
        // Timer countdown
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Max(0, Mathf.RoundToInt(timeLeft));

        // End game or add bonus at the end of the level
        if (timeLeft <= 0)
        {
            // End the level or add time bonus to score here
            AddScore(Mathf.RoundToInt(timeLeft)); // Adds remaining time as bonus points
            timeLeft = 0; // Stop the countdown
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText != null) // Check if the reference is set
        {
            scoreText.text = "Score: " + score;
        }
    }
    void Start()
{
    UpdateScore(); // Initialize score text
}
}
