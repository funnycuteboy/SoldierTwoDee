using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        //Destroy particle system when it's done playing
        if (particle != null && !particle.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}