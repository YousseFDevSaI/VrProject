using System.Diagnostics;
using UnityEngine;

public class MonitorObjects : MonoBehaviour
{
    public Transform object1; // Reference to the first object
    public Transform object2; // Reference to the second object
    public Transform object3; // Reference to the third object
    public float proximityThreshold = 1.0f; // Distance threshold for proximity check

    private void Update()
    {
        if (object1 == null || object2 == null || object3 == null)
        {
            UnityEngine.Debug.LogError("One of the objects is not assigned.");
            return;
        }

        // Check if the distance between all pairs of objects is less than or equal to the threshold
        bool objectsCloseEnough = AreObjectsCloseEnough();

        // If all objects are close enough, stop the game
        if (objectsCloseEnough)
        {
            UnityEngine.Debug.Log("Stopping the game: All objects are close enough to the plane.");
            StopGame();
        }
    }

    private bool AreObjectsCloseEnough()
    {
        float distance1 = Vector3.Distance(transform.position, object1.position);
        float distance2 = Vector3.Distance(transform.position, object2.position);
        float distance3 = Vector3.Distance(transform.position, object3.position);

        return distance1 <= proximityThreshold && distance2 <= proximityThreshold && distance3 <= proximityThreshold;
    }

    private void StopGame()
    {
        // Logic to stop the game, e.g., stop time
        Time.timeScale = 0; // Stops the game by pausing the time
    }
}
