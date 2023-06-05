using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    public bool playerCollision = false;
    public GameObject Player;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == Player)
        {

            playerCollision = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == Player)
        {

            playerCollision = false;
        }
    }
}
