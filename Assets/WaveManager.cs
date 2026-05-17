using UnityEngine;
using TMPro; // For TextMeshPro

public class WaveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Drag the objective text here
    public GameObject thoughtsPanel; // Drag the ThoughtsPanel here
    public TextMeshProUGUI thoughtsText; // Drag the ThoughtsText here
    
    private EnemySpawner enemySpawner;
    
    void Start()
    {
        // Find the EnemySpawner in the scene
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
        // Set initial objective text
        objectiveText.text = "Objective: Shoot all enemy soldiers";
        
        // Hide thoughts panel at start
        thoughtsPanel.SetActive(false);
    }
    
    void Update()
    {
        if (enemySpawner != null)
        {
            int currentWave = enemySpawner.currentWave;
            
            // Update objective text based on wave
            if (currentWave <= 3)
            {
                objectiveText.text = "Objective: Shoot all enemy soldiers";
            }
            else if (currentWave >= 4 && currentWave <= 6)
            {
                objectiveText.text = "Objective: Shoot all enemies";
            }
            else if (currentWave >= 7)
            {
                objectiveText.text = "Objective: Keep fighting!";
            }
            
            // Update thoughts panel based on wave
            UpdateThoughts(currentWave);
        }
    }
    
    void UpdateThoughts(int wave)
    {
        // Waves 2-4: Show first thought
        if (wave >= 2 && wave <= 4)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "It's ok. I'm serving my country. All I'm doing is shooting hostiles.";
        }
        // Waves 5-8: Show second thought
        else if (wave >= 5 && wave <= 8)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "Civilians inevitably get caught in the crossfire. I'm just following orders.";
        }
        // Waves 9+: Show third thought
        else if (wave >= 9)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "My duty is not to question orders.";
        }
        // Waves 1 only: Hide panel
        else
        {
            thoughtsPanel.SetActive(false);
        }
    }
}