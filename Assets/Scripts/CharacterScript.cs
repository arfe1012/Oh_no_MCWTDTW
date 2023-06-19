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
    }

    // Update is called once per frame
    void Update()
    {
        float headHeight = camera.transform.localPosition.y;
        float scale = defaultHeight / headHeight;
        Debug.Log(scale);
        CC = GameObject.Find("XR Origin").GetComponent<CharacterController>();
        //CC.height = defaultHeight * scale;
        Debug.Log("CC height" + CC.height);
    }
}
