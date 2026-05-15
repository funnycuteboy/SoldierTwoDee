using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Bullet created at position: " + transform.position);
        Debug.Log("Bullet tag: " + gameObject.tag);
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("Bullet velocity: " + rb.linearVelocity);
        }
        else
        {
            Debug.LogError("Bullet has NO Rigidbody2D!");
        }
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            Debug.Log("Bullet collider is trigger: " + col.isTrigger);
        }
        else
        {
            Debug.LogError("Bullet has NO Collider!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet OnTriggerEnter2D: Hit " + other.gameObject.name);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet OnCollisionEnter2D: Hit " + collision.gameObject.name);
    }
    
    void OnBecameInvisible()
    {
        Debug.Log("Bullet left screen, destroying");
        Destroy(gameObject);
    }
}