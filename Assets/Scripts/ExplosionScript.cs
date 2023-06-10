using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public bool isHit;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            ani.Play("Explode");
            
        }
    }
    void EndOfAnimation()
    {
        Debug.Log("Animation Ended");
        this.gameObject.SetActive(false);
    }
}
