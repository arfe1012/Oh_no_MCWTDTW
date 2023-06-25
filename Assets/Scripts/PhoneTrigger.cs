using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PhoneTrigger : MonoBehaviour
{
    public AudioSource ringing;
    public AudioSource intro;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "hoerer")
        {
            ringing.Stop();
            intro.Play();
        }
    }
}
