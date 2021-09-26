using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraMain;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform firePoint;

    void Start()
    {
        
    }

    void Update()
    {
        EnableLaser();
        UpdateLaser();
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    void UpdateLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }

    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
