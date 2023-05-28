using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Reference to the player object
    public Vector3 offset; // Offset from the target position
    public float smoothSpeed = 0.125f; // Speed of camera movement

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate desired camera position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate towards desired position
        transform.position = smoothedPosition; // Update camera position

        transform.LookAt(target); // Make the camera look at the target (character)
    }
}
