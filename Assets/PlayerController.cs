using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
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
            rb.velocity = Vector2.up * bulletSpeed;
            Debug.Log("Bullet velocity set to: " + rb.velocity);
        }
        else
        {
            Debug.LogError("Bullet prefab has no Rigidbody2D!");
        }
    }
}