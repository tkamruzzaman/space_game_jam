using UnityEngine;

public class SpiralProjectile : MonoBehaviour
{
    public float shootSpeed = 8f;       // Initial forward speed
    public float gravityStrength = 2f;  // Pull towards center
    public float spiralStrength = 5f;   // How much it spirals around the center
    public float stopDistance = 0.2f;   // When to destroy projectile

    private Vector2 velocity;
    private Transform center;
   
    void Start()
    {
        center = null; // we'll just spiral towards (0,0)
        //Vector2 shootDir = transform.up; // front facing (local up)
        velocity = OrbitController.Instance.child.transform.up * shootSpeed;
    }

    void Update()
    {
        Vector2 centerPos = Vector2.zero;
        Vector2 toCenter = centerPos - (Vector2)transform.position;
        float distance = toCenter.magnitude;

        if (distance < stopDistance)
        {
            Destroy(gameObject);
            return;
        }

        // Normalize direction to center
        Vector2 dirToCenter = toCenter.normalized;

        // Tangential direction (perpendicular to center pull)
        Vector2 tangent = new Vector2(-dirToCenter.y, dirToCenter.x);

      
        velocity += gravityStrength * Time.deltaTime * dirToCenter;

      
        //    scale it by current speed to "curve" inward
        velocity = Vector2.Lerp(velocity, tangent * velocity.magnitude, spiralStrength * Time.deltaTime);

       
        velocity *= 0.995f;

        // Move projectile
        transform.position += (Vector3)(velocity * Time.deltaTime);

        // Rotate projectile to face movement
        if (velocity.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


}
