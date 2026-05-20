using UnityEngine;

public class ParticleSorting : MonoBehaviour
{
    void Start()
    {
        ParticleSystemRenderer renderer = GetComponent<ParticleSystemRenderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = 100;
        }
    }
}