using UnityEngine;

public class AquaticMine : MonoBehaviour
{
    // Adjustable parameters for modifying behavior in Unity's inspector
    public float verticalSpeed = 0.5f;
    public float verticalDistance = 0.1f;
    public float horizontalSpeed = 1.0f;
    public float horizontalDistance = 0.1f;

    // Store the initial position
    private Vector3 initialPosition;

    void Start()
    {
        // Save the initial position of the mine
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position for the mine
        float newY = initialPosition.y + Mathf.Sin(Time.time * verticalSpeed) * verticalDistance;
        float newX = initialPosition.x + Mathf.Cos(Time.time * horizontalSpeed) * horizontalDistance;

        // Update the position of the mine
        transform.position = new Vector3(newX, newY, initialPosition.z);
    }
}