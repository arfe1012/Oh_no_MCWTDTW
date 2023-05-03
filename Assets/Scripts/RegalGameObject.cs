using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegalGameObject : MonoBehaviour
{
    private Vector3 start;
    public float zPosition;
    public Vector3 stepSize;
    private bool socketActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(socketActivated)
        {
            if(transform.position.z > zPosition)
            {
                Debug.Log("Position is been transformed");
                transform.position -= stepSize;
            }
        }
    }

    public void setSocketActivated()
    {
        socketActivated = true;
        Debug.Log("socket has been set to: " + socketActivated);
    }
}
