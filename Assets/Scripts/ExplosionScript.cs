using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public bool isHit;
    Animator ani;
    float timer = 0.0f;
    const float TIMETOEXPLODE = 1.0f;
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
            timer += Time.deltaTime;
            if (timer >= TIMETOEXPLODE)
            {
                ani.Play("Explode");
            } 
        } else
        {
            timer = 0.0f;
        }
    }
    void EndOfAnimation()
    {
        Debug.Log("Animation Ended");
        this.gameObject.SetActive(false);
    }
}
