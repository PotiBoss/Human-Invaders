using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform firePoint;

    Vector3 startingPos;
    int layerMask;
    Vector3 laserPos;


    void Start()
    {
        layerMask = LayerMask.GetMask("Enemy");
        laserPos = GetComponent<LineRenderer>().GetPosition(1);
    }


    void Update()
    {

        if (lineRenderer.enabled)
        {
            startingPos = GetComponentInParent<Transform>().position; // ship transform pos update

            RaycastHit2D hit = Physics2D.Raycast(startingPos, Vector2.up, laserPos.y, layerMask); // raycast range and direction

            if (hit.collider != null)
            {
                Vector3 hitPoint = new Vector3(0, hit.point.y + Mathf.Abs(startingPos.y), 0);
                lineRenderer.SetPosition(1, hitPoint);


                GetComponent<Damage>().OnTriggerEnter2D(hit.collider);


            }
            else
            {
                lineRenderer.SetPosition(1, laserPos);
            }
        }
    }
}
