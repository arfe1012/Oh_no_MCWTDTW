using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Vector3[] points = new Vector3[2];
    public LineRenderer line;
    public GameObject origin;
    Vector3 originVector;
    public Vector3 direction;
    public int layer;
    int layerMask;
    public bool hitByLight;
    public bool isSource;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << layer;
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        originVector = origin.transform.position;
        points[0] = origin.transform.localPosition;

        RaycastHit hit;
        if (hitByLight == true || isSource == true)
        {
            direction = origin.transform.forward;
            if (Physics.Raycast(originVector, direction, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(originVector, direction * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                points[1] = hit.transform.position - originVector;
                
                if (hit.transform.GetComponentInParent<Raycast>())
                {
                    hit.transform.GetComponentInParent<Raycast>().hitByLight = true;
                } else if (hit.transform.GetComponentInParent<ExplosionScript>())
                {
                    hit.transform.GetComponentInParent<ExplosionScript>().isHit = true;
                }
            }
            else
            {
                Debug.DrawRay(originVector, direction * 1000, Color.white);
                Debug.Log("Did not Hit");
                points[1] = direction * 1000;
                hitByLight = false;
            }
        } else
        {
            points[1] = points[0];
        }
        renderLine();
    }

    void renderLine()
    {
        line.positionCount = 2;
        line.SetPositions(points);
    }
}
