using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public bool isHit;
    Animator ani;
    float timer = 0.0f;
    const float TIMETOEXPLODE = 2.0f;
    public AudioSource explosionAudio;
    public GameObject chain;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHit)
        {
            if(!explosionAudio.isPlaying)
            {
                explosionAudio.Play();
            }
            timer += Time.deltaTime;
            this.transform.position += this.transform.right.normalized * 0.005f * (Mathf.Sin(Time.time * 15));
            if (timer >= TIMETOEXPLODE)
            {
                ani.Play("Explode");
            } 
        } else
        {
            timer = 0.0f;
            explosionAudio.Stop();
        }
        isHit = false;
    }
    void EndOfAnimation()
    {        
        this.gameObject.SetActive(false);
        chain.SetActive(false);
        this.GetComponentInParent<EvilFalldown>().chains -= 1;
    }
}
