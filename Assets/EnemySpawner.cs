using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int currentWave = 1;
    public int enemiesToSpawn = 1;
    private int enemiesAlive = 0;
    
    public float minSpeed = 1f;
    public float maxSpeed = 4f;
    
    public Sprite[] enemySprites;
    
    private GameCompletion gameCompletion; 
    
    void Start()
    {
        gameCompletion = FindObjectOfType<GameCompletion>(); 
        SpawnWave();
    }
    
    void Update()
    {
        // Check if we've reached the final wave (13)
        if (currentWave >= 13)
        {
            // Don't spawn more waves, just check if all enemies are dead to trigger completion
            if (enemiesAlive <= 0)
            {
                // Use the cached reference instead of finding it every time
                if (gameCompletion != null)
                {
                    gameCompletion.CompleteGame();
                }
            }
            return; // Stop here, don't spawn more waves
        }
    
        if (enemiesAlive <= 0)
        {
            currentWave++;
            enemiesToSpawn = currentWave;
        
            if (enemiesToSpawn > 5)
            {
                enemiesToSpawn = 5;
            }
        
            SpawnWave();
        }
    }
    
    void SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // randomized spawn point
            float randomX;
            if (Random.value > 0.5f)
                randomX = Random.Range(-6f, -3f);  // left
            else
                randomX = Random.Range(3f, 6f);    // right
                
            float randomY = Random.Range(2f, 4f);   // height
            
            Vector2 spawnPosition = new Vector2(randomX, randomY);
            
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemiesAlive++;
            
            // randomized spd
            Enemy enemyScript = newEnemy.GetComponent<Enemy>();
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            enemyScript.SetSpeed(randomSpeed);
            enemyScript.SetSpawner(this);
            
            enemyScript.SetRandomSprite(enemySprites);
        }
        
        Debug.Log("Wave " + currentWave + " started with " + enemiesToSpawn + " enemies!");
    }
    
    public void EnemyDied()
    {
        enemiesAlive--;
    }
}