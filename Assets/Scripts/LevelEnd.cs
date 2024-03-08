using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
    {
        EndLevel();
    }
}
public void EndLevel()
{
    // Find the GameManager1 component in the scene
    GameManager1 gameManager = FindObjectOfType<GameManager1>();
    if (gameManager != null)
    {
        int score = gameManager.score;
        int time = Mathf.RoundToInt(gameManager.timeLeft);

        // Save the current score and remaining time
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("RemainingTime", time);

        // Load the LevelComplete scene
        SceneManager.LoadScene("LevelComplete");
    }
    else
    {
        Debug.LogError("GameManager1 not found in the scene.");
    }
}


}
