using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerzeEntzünden : MonoBehaviour
{
    public GameObject BannstabFlamme;
    public GameObject Flamme;




    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == BannstabFlamme)
        {

            Flamme.SetActive(true);
        }
    }
}
