using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private float direction = 1f;
    private float leftBoundary = -5f;
    private float rightBoundary = 5f;
    
    void Update()
    {
        // move 
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        
        // change direction @ boundareies
        if (transform.position.x >= rightBoundary)
        {
            direction = -1f;
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1f;
        }
    }
}