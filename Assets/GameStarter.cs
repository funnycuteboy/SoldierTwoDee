using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject startScreenPanel;
    public GameObject player;
    public GameObject enemySpawner;
    public GameObject gameTimer; // Add this
    
    void Start()
    {
        // Freeze the game at start
        Time.timeScale = 0f;
        
        // Make sure start screen is visible
        startScreenPanel.SetActive(true);
        
        // Disable player movement and enemy spawning
        player.GetComponent<PlayerController>().enabled = false;
        enemySpawner.GetComponent<EnemySpawner>().enabled = false;
        
        // Disable game timer at start
        if (gameTimer != null)
            gameTimer.SetActive(false);
    }
    
    public void StartGame()
    {
        // Hide start screen
        startScreenPanel.SetActive(false);
        
        // Unfreeze game
        Time.timeScale = 1f;
        
        // Enable player and enemies
        player.GetComponent<PlayerController>().enabled = true;
        enemySpawner.GetComponent<EnemySpawner>().enabled = true;
        
        // Enable game timer
        if (gameTimer != null)
            gameTimer.SetActive(true);
    }
}