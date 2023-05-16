using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannstab : MonoBehaviour
{
    public GameObject Flame1;
    public GameObject Flame2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pullTrigger()
    {
        Flame1.SetActive(true);
        Flame2.SetActive(true);
    }

    public void releaseTrigger()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
    }
}
