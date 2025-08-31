using UnityEngine;

using Unity.Cinemachine;
using System.Collections.Generic;

public class CameraZoom2D : MonoBehaviour
{
    public CinemachineCamera vCam; // Assign your Virtual Camera
    public Transform player;               // Assign your player

    public float minZoom = 5f;             // Zoomed-in size
    public float maxZoom = 10f;            // Zoomed-out size
    public float zoomSpeed = 2f;            // How fast camera zooms
    float targetZoom = 4;


    Dictionary<int, float> zoomDict = new Dictionary<int, float>()
    {
        { 0, 4f },
        { 1, 4.5f },
        { 2, 5f }
    };

    void Update()
    {


        // Smoothly interpolate the orthographic size
        // vCam.m_Lens.OrthographicSize = Mathf.Lerp(vCam.m_Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        vCam.Lens.OrthographicSize = Mathf.Lerp(vCam.Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }


    public void SetTargetZoom(int tZoom)
    {
        targetZoom = zoomDict[tZoom];
    }
}
