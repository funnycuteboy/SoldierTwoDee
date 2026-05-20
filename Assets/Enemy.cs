using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private float direction = 1f;
    private float leftBoundary = -6f;
    private float rightBoundary = 6f;
    private float topBoundary = 4.5f;
    private float bottomBoundary = -4.5f;
    
    public GameObject deathParticlePrefab;
    private EnemySpawner spawner;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // DEBUG: Check if spriteRenderer is found
        if (spriteRenderer == null)
        {
            Debug.LogError("Enemy: No SpriteRenderer found!");
        }
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
    
    public void SetRandomSprite(Sprite[] sprites)
    {
        Debug.Log("=== SetRandomSprite CALLED ===");
        
        if (sprites == null)
        {
            Debug.LogError("SetRandomSprite: sprites array is NULL!");
            return;
        }
        
        Debug.Log("SetRandomSprite: sprites length = " + sprites.Length);
        
        if (spriteRenderer == null)
        {
            Debug.LogError("SetRandomSprite: spriteRenderer is NULL!");
            return;
        }
        
        if (sprites.Length == 0)
        {
            Debug.LogError("SetRandomSprite: sprites array is EMPTY!");
            return;
        }
        
        int randomIndex = Random.Range(0, sprites.Length);
        Debug.Log("SetRandomSprite: randomIndex = " + randomIndex);
        Debug.Log("SetRandomSprite: sprite name = " + sprites[randomIndex].name);
        
        spriteRenderer.sprite = sprites[randomIndex];
        
        // Force a temporary scale so enemy is visible
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        
        Debug.Log("SetRandomSprite: COMPLETE - sprite assigned!");
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
        if (other.CompareTag("Bullet"))
        {
            if (deathParticlePrefab != null)
            {
                Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            }
            
            if (spawner != null)
            {
                spawner.EnemyDied();
            }
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}