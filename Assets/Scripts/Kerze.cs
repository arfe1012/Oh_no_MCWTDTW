using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kerze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name == "BannstabFlamme1")
        //{
            Debug.Log("Collision enter detected" + collision.gameObject.name);
        //}
    }
    void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.name == "BannstabFlamme1")
        //{
            Debug.Log("Collision exit detected" + collision.gameObject.name);
        //}
    }
}
