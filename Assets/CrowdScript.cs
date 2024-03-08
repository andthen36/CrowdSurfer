using UnityEngine;

public class CrowdMember : MonoBehaviour
{
    private GameManager1 gameManager;
    private AudioSource audioSource;
    public AudioClip[] hitSounds; // Array of sounds that play when the crowd member is hit

    void Start()
    {
        // Find the GameManager in the scene and store a reference to it
        gameManager = FindObjectOfType<GameManager1>();

        // Get the AudioSource component from the crowd member
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // If there isn't an AudioSource component, add one
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the crowd member has been hit by the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If hit by the player and the GameManager reference exists, increase the score
            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }
            else
            {
                Debug.LogError("GameManager not found in the scene.");
            }

            // Play a random hit sound if any are available
            if (hitSounds.Length > 0)
            {
                AudioClip clip = hitSounds[Random.Range(0, hitSounds.Length)];
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
