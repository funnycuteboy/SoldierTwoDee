using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject gameOverPanel;
    public PlayerController playerController;
    public EnemySpawner enemySpawner;
    
    private float timeSinceLastShot = 0f;
    private bool gameRunning = true;
    
    void Start()
    {
        // Make sure game over panel is hidden at start
        gameOverPanel.SetActive(false);
    }
    
    void Update()
    {
        if (!gameRunning) return;
        
        // Check if player shot this frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reset timer when player shoots
            timeSinceLastShot = 0f;
        }
        else
        {
            // Increase timer
            timeSinceLastShot += Time.deltaTime;
        }
        
        // Check if 7 seconds passed without shooting
        if (timeSinceLastShot >= 7f)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        gameRunning = false;
        
        // Show game over screen
        gameOverPanel.SetActive(true);
        
        // Freeze the game
        Time.timeScale = 0f;
        
        // Disable player and enemy spawner
        playerController.enabled = false;
        enemySpawner.enabled = false;
    }
    
    public void RestartLevel()
    {
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}