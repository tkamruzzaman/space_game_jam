using UnityEngine;
using System.Collections.Generic;

public class OrbitController : MonoBehaviour
{
    public static OrbitController Instance { get; private set; }   
    [SerializeField] Transform center;
    public List<Orbit> orbits;

    int currentOrbit = 0;
    float angle = 0f;

    float currentRadius = 0f;       // The current radius, lerped
    float radiusLerpSpeed = 5f;     // How fast to transition

    [SerializeField]int orbitStep;
    int stepLeft;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: keep across scenes
    }
    private void Start()
    {
        stepLeft = orbitStep;
        if (orbits.Count > 0)
            currentRadius = orbits[currentOrbit].radius; // Initialize radius
    }

    private void Update()
    {
        if (orbits.Count == 0) return;
        if (stepLeft > 0)
        {
            HandleOrbitInput();
        }
        UpdateOrbitRadius();
        MoveAlongOrbit();
    }

    void HandleOrbitInput()
    {
        // Determine input direction: +1 for Up, -1 for Down, 0 for none
        int input = (Input.GetKeyDown(KeyCode.UpArrow) ? 1 : (Input.GetKeyDown(KeyCode.DownArrow) ? -1 : 0));
        if (input == 0) return;

        // Calculate new orbit
        int newOrbit = Mathf.Clamp(currentOrbit + input, 0, orbits.Count - 1);

        // Only update if orbit changed
        stepLeft -= (newOrbit != currentOrbit) ? 1 : 0;
        currentOrbit = newOrbit;

         Debug.Log(stepLeft);
    }


    void UpdateOrbitRadius()
    {
        // Smoothly interpolate current radius to target orbit radius
        float targetRadius = orbits[currentOrbit].radius;
        currentRadius = Mathf.Lerp(currentRadius, targetRadius, Time.deltaTime * radiusLerpSpeed);
    }

    void MoveAlongOrbit()
    {
        // Move angle based on current orbit speed
        angle += orbits[currentOrbit].speed * Time.deltaTime;
        if (angle > 360f) angle -= 360f;

        float x = center.position.x + currentRadius * Mathf.Cos(angle);
        float y = center.position.y + currentRadius * Mathf.Sin(angle);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    // Gizmos code unchanged
    private void OnDrawGizmos()
    {
        if (center == null || orbits.Count == 0) return;
        Gizmos.color = Color.yellow;
        foreach (var orbit in orbits)
        {
            DrawCircle(center.position, orbit.radius);
        }
    }

    void DrawCircle(Vector3 center, float radius, int segments = 50)
    {
        Vector3 prevPoint = center + new Vector3(radius, 0, 0);
        for (int i = 1; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }
    }


}
