using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    
    private Animator animator; // ADD THIS
    
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.localScale = new Vector3(1, 1, 1); // Force normal scale
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        
        // ADD THIS - Update animation based on movement
        animator.SetFloat("Speed", Mathf.Abs(move));
        
        // ADD THIS - Flip sprite direction
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6f, 6f);
        transform.position = pos;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        Debug.Log("SHOOT WAS CALLED");
        
        Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        bullet.tag = "Bullet";
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * bulletSpeed;
            Debug.Log("Bullet velocity set to: " + rb.linearVelocity);
        }
        else
        {
            Debug.LogError("Bullet prefab has no Rigidbody2D!");
        }
    }
}