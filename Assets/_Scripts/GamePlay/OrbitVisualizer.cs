using UnityEngine;
using System.Collections.Generic;

public class OrbitVisualizer : MonoBehaviour
{
    public Transform center;
    public List<Orbit> orbits;
    public Material lineMaterial;    // Assign a material for LineRenderers
    public float lineWidth = 0.02f;

    private List<LineRenderer> lines = new List<LineRenderer>();

    void Start()
    {
        
        orbits = OrbitController.Instance.orbits;
        if (center == null || orbits.Count == 0) return;

        foreach (var orbit in orbits)
        {
            // Create a new GameObject for the line
            GameObject lineObj = new GameObject("OrbitLine");
            lineObj.transform.parent = transform;

            // Add LineRenderer
            LineRenderer line = lineObj.AddComponent<LineRenderer>();
            line.material = lineMaterial;
            line.widthMultiplier = lineWidth;
            line.positionCount = 0;
            line.loop = true;
            line.alignment = LineAlignment.View;
            // Draw the circle
            DrawOrbit(line, orbit.radius);
            lines.Add(line);
        }
    }

    void DrawOrbit(LineRenderer line, float radius, int segments = 300)
    {
        line.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            Vector3 pos = center.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            line.SetPosition(i, pos);
        }
    }
}
