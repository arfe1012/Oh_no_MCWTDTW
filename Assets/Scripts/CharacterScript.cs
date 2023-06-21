using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public Camera camera;
    private float defaultHeight = 1.7f;
    private CharacterController CC;


    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("XR Origin").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float headHeight = camera.transform.localPosition.y;
        if(headHeight < 2 && headHeight > 0.5)
        {
            CC.height = headHeight;
        }
    }
}
