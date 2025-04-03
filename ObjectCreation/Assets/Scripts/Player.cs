using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3f; // Speed of the player
    float forwardSpeedUp = 0.3f; // Speed increment for forward movement
    float rotateSpeed = 2f; // Speed of rotation
    bool isMouseControl = true; // Flag to check if mouse control is enabled
    float secondsSinceLastFire = 0f; // Time since the last fire action
    float fireRate = 0.2f; // Rate of fire for the egg
    public GameObject eggPrefab; // Prefab for the egg object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchControls(); // Check for control switch input
        }
        if (Input.GetKey(KeyCode.Space))  // Keeps detecting while key is held
        {
            FireEgg(); // Fire an egg when space is pressed
        }
        if (isMouseControl)
        {
            FollowMouse(); // Follow mouse position if mouse control is enabled
        }
        else
        {
            FollowKeyboard(); // Follow keyboard input if mouse control is disabled
        }
        secondsSinceLastFire += Time.deltaTime; // Increment time since last fire
    }

    void FireEgg()
    {
        if (secondsSinceLastFire >= fireRate) // Check if enough time has passed to fire again
        {
            // Fire an egg from the player
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
            Debug.Log("Firing egg!");
            secondsSinceLastFire = 0f; // Reset the timer
        }
    }

    void FollowMouse()
    {
        // Follow the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 for 2D
        transform.position = mousePosition;
    }

    void FollowKeyboard()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
        {
            speed += forwardSpeedUp * Time.deltaTime; // accelerate forward
        }
        if(Input.GetKey(KeyCode.S))
        {
            speed -= forwardSpeedUp * Time.deltaTime; // decelerate backward
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime); // rotate left
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime); // rotate right
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an object tagged "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy!");
        }
    }

    void SwitchControls()
    {
        // Switch controls between keyboard and mouse
        isMouseControl = !isMouseControl; // Switch to other control
        Debug.Log("Switched controls!");
    }
}
