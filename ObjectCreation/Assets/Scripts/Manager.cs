using UnityEngine;

public class Manager : MonoBehaviour
{
    int planeCount = 0; // Number of planes in the scene
    int planeLimit = 10; // Maximum number of planes allowed in the scene
    public GameObject planePrefab; // Prefab for the plane object
    public Camera mainCamera; // Reference to the main camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the number of planes is less than the limit
        if (planeCount < planeLimit)
        {
            // Call the SpawnPlane method to spawn a new plane
            SpawnPlane();
            // Increment the plane count
            planeCount++;
        }
    }

    void SpawnPlane()
    {
        // Check if the number of planes is less than the limit
        if (planeCount < planeLimit)
        {
            // Get the camera's screen boundaries in world space
            Vector3 min = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            Vector3 max = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

            // Random position within the screen bounds
            float randomX = Random.Range(min.x, max.x);
            float randomY = Random.Range(min.y, max.y);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            // Spawn object
            Instantiate(planePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void DisplayPlaneCount(Vector3 position)
    {
        //display the plane count at the given position as textmeshpro
    }

    void PlaneDestroyed()
    {
        // Decrement the plane count when a plane is destroyed
        planeCount--;
    }
}
