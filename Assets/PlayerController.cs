using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    
    void Update()
    {
        // a/d // l/r mvmt
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
        
        // shoot w/ spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        // spawn bullet @ players pos
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // bullet force
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * bulletSpeed;
    }
}