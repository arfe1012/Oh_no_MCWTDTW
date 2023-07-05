using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteineFallenManchmal : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Wait());
        
    }

    


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().useGravity = false;
    }
}
