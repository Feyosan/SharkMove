using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 5f;
    public float frequency = 2f;
    public float magnitude = 0.5f;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        // Movement pattern in update function
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}