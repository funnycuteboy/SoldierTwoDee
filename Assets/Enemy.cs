using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private float direction = 1f;
    private float leftBoundary = -6f;
    private float rightBoundary = 6f;
    private float topBoundary = 4.5f;
    private float bottomBoundary = -4.5f;
    
    private EnemySpawner spawner;
    private Rigidbody2D rb;
    
    void Start()
    {
        Debug.Log("=== ENEMY STARTED ===");
        
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
        
        Debug.Log("Enemy trigger status: " + col.isTrigger);
        Debug.Log("Enemy tag: " + gameObject.tag);
    }
    
    void Update()
    {
        rb.linearVelocity = new Vector2(direction * speed, 0f);
        
        Vector3 pos = transform.position;
        if (pos.x >= rightBoundary)
        {
            pos.x = rightBoundary;
            direction = -1f;
        }
        else if (pos.x <= leftBoundary)
        {
            pos.x = leftBoundary;
            direction = 1f;
        }
        
        if (pos.y > topBoundary)
        {
            pos.y = topBoundary;
        }
        else if (pos.y < bottomBoundary)
        {
            pos.y = bottomBoundary;
        }
        
        transform.position = pos;
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    
    public void SetSpawner(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("!!! ONTRIGGERENTER2D WAS CALLED !!!");
        Debug.Log("Hit something: " + other.gameObject.name);
        Debug.Log("Hit tag: " + other.tag);
        
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("!!! ENEMY HIT BY BULLET - DESTROYING !!!");
            
            if (spawner != null)
            {
                spawner.EnemyDied();
            }
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}