using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    
    public void Play()
    {
        if (particle != null)
        {
            particle.Play();
        }
    }
}