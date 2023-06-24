using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFalldown : MonoBehaviour
{
    public int chains;
    float velocity;
    // Start is called before the first frame update
    void Start()
    {
        chains = 3;
        velocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (chains <= 0)
        {
            this.transform.position -= new Vector3(0, velocity * Time.deltaTime, 0);
            velocity += 5;
        }
    }
}
