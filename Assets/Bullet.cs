using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // if bullet hits enemy
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy enemy
            Destroy(gameObject); // Destroy bullet
        }
    }
    
    void OnBecameInvisible()
    {
        // destroy bullet when it leaves screen
        Destroy(gameObject);
    }
}