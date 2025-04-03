using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 100f; // Health of the enemy
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Debug.Log("Egg hit enemy!"); // Log message for egg collision
            health -= 25f; // Decrease health on egg collision
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit enemy!"); // Log message for egg collision
            health -= 100f; // Decrease health on egg collision
        }
        if (health <= 0f)
        {
            Manager.Instance.PlaneDestroyed(); // Notify the game manager that the enemy is destroyed
            Destroy(gameObject); // Destroy the enemy if health is zero or less
        }
    }
}
