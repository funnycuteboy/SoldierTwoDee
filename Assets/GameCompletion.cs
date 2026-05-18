using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    public GameObject completionPanel;
    public GameObject gameTimer;
    public PlayerController playerController;
    public EnemySpawner enemySpawner;
    
    private bool gameCompleted = false;
    
    void Start()
    {
        // Make sure completion panel is hidden at game start
        if (completionPanel != null)
        {
            completionPanel.SetActive(false);
        }
    }
    
    public void CompleteGame()
    {
        if (gameCompleted) return;
        gameCompleted = true;
        
        // Show completion screen
        completionPanel.SetActive(true);
        
        // Freeze the game
        Time.timeScale = 0f;
        
        // Disable player and enemy spawner
        playerController.enabled = false;
        
        if (enemySpawner != null)
            enemySpawner.enabled = false;
        
        // Disable game timer if it exists
        if (gameTimer != null)
            gameTimer.SetActive(false);
    }
    
    public void RestartGame()
    {
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        // If running in Unity Editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If built as a game, quit
            Application.Quit();
#endif
    }
}