using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public float TheVoid;
    public GameObject spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < TheVoid)
        {
            this.transform.position = spawnPosition.transform.position;
        }
    }
}
