using UnityEngine;
using UnityEngine.UI; // For legacy UI
using UnityEngine.SceneManagement;

public class EndLevelController : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text totalScoreText;
    public Button continueButton;
    public string nextLevelName; // Assign this in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve score data, assuming they are saved in PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);
        int remainingTime = PlayerPrefs.GetInt("RemainingTime", 0);
        int totalScore = score + (remainingTime * 2); // Calculate total score

        // Update UI elements
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (timeText != null) timeText.text = "Time Left: " + remainingTime;
        if (totalScoreText != null) totalScoreText.text = "Total Score: " + totalScore;

        // Set up button listener
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(() => {
                SceneManager.LoadScene(nextLevelName);
            });
        }
    }
}
