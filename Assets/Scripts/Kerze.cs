using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kerze : MonoBehaviour
{
    private GameObject ownFlame1;
    private GameObject ownFlame2;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}