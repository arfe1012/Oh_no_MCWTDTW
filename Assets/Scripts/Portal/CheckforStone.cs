using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforStone : MonoBehaviour
{

    public bool socketActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (socketActivated)
        {

        }
    }
    public void setSocketActivated()
    {
        socketActivated = true;
        Debug.Log("socket has been set to: " + socketActivated);
    }
}
