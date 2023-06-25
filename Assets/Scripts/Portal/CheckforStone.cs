using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforStone : MonoBehaviour
{
    public GameObject Particles;
    public GameObject RightStone;

    public bool socketActivated = false;
    public bool rightStoneInSocket;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSocketActivated()
    {
        socketActivated = true;
        Debug.Log("socket has been set to: " + socketActivated);
    }

    public void ActivateParticle()
    {
        Particles.SetActive(true);
    }
    public void DeactivateParticle()
    {
        Particles.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == (RightStone.name + "(Clone)"))
        {

            rightStoneInSocket = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == (RightStone.name + "(Clone)"))
        {

            rightStoneInSocket = false;
        }
    }
}
