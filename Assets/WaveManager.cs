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
            else if (currentWave >= 4 && currentWave <= 9)
            {
                objectiveText.text = "Objective: Shoot all enemies";
            }
            else if (currentWave >= 10 && currentWave <= 13)
            {
                objectiveText.text = "Objective: Shoot everything you see.";
            }
            
            // Update thoughts panel based on wave
            UpdateThoughts(currentWave);
        }
    }
    
    void UpdateThoughts(int wave)
    {
        if (wave >= 2 && wave <= 3)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "They signed up for this. Just doing my job.";
        }
        
        else if (wave >= 4 && wave <= 5)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "I don't see people. I only see uniforms.";
        }
        
        else if (wave >= 6 && wave <= 7)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "My duty is not to question orders.";
        }
        
        else if (wave >= 8 && wave <= 9)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "I'm a weapon. Weapons shouldn't feel guilt.";
        }
        
        else if (wave >= 10 && wave <= 13)
        {
            thoughtsPanel.SetActive(true);
            thoughtsText.text = "I can't stop. If I stop, I'll think.";
        }
        
        // Waves 1 only: Hide panel
        else
        {
            thoughtsPanel.SetActive(false);
        }
    }
}