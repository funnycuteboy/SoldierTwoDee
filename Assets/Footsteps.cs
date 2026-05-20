using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public ParticleSystem dustParticles;
    
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        bool isMoving = Mathf.Abs(move) > 0.1f;
        
        if (isMoving)
        {
            if (dustParticles != null && !dustParticles.isPlaying)
            {
                dustParticles.Play();
            }
        }
        else
        {
            if (dustParticles != null && dustParticles.isPlaying)
            {
                dustParticles.Stop();
            }
        }
    }
}