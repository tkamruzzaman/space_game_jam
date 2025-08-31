using UnityEngine;

public class MagnetCollector : MonoBehaviour
{
    public float radius = 5f;          // Magnet detection radius
    public float pullSpeed = 20f;      // How fast objects get sucked
    public LayerMask pullableLayer;    // Layer of objects to pull

    void Update()
    {
        // Find all objects in radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, pullableLayer);

        foreach (Collider2D hit in hits)
        {
            // Move directly towards the magnet
            hit.transform.position = Vector3.MoveTowards(
                hit.transform.position,
                transform.position,
                pullSpeed * Time.deltaTime
            );

            // Destroy if close enough
            if (Vector3.Distance(hit.transform.position, transform.position) < 0.1f)
            {
                Destroy(hit.gameObject);
            }
        }
    }

    // Optional: visualize radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
