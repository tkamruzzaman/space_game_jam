using UnityEngine;

public class FloatingDebris2D : MonoBehaviour
{
    public Vector2 driftSpeed = new Vector2(0.5f, 0.5f);  // movement speed
    public float rotationSpeed = 30f;                     // degrees per second

    private Vector2 direction;

    void Start()
    {
        // Random initial direction
        direction = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    void Update()
    {
        // Drift in space
        transform.position += (Vector3)(direction * driftSpeed * Time.deltaTime);

        // Optional rotation
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
