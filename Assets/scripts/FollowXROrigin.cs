using UnityEngine;

public class FollowXROrigin : MonoBehaviour
{
    public Transform xrOrigin; // Reference to the XR Origin (player)
    public float followSpeed = 2.0f; // Speed at which the object follows
    public float messageDistance = 1.0f; // Distance to trigger the message

    private void Update()
    {
        if (xrOrigin == null)
        {
            UnityEngine.Debug.LogError("XR Origin is not assigned.");
            return;
        }

        // Follow the XR Origin smoothly
        Vector3 direction = xrOrigin.position - transform.position;
        if (direction.magnitude > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, xrOrigin.position, followSpeed * Time.deltaTime);
        }

        // Check the distance and display a message
        UnityEngine.Debug.Log($"Distance to XR Origin: {direction.magnitude}");
        if (direction.magnitude <= messageDistance)
        {
            UnityEngine.Debug.Log("You are too close!");
            EndGame();
        }
    }

    private void EndGame()
    {
        // Logic to end the game, e.g., stop time
        Time.timeScale = 0; // Stops the game by pausing the time
        UnityEngine.Debug.Log("Game Over");
    }
}
