using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    public bool playerJustEntered = false;
    public bool playerJustExited = false;
    public bool playerInCollider = false;
    public GameObject Player;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == Player)
        {

            playerJustEntered = true;  //Wird vom Portal wieder ausgeschaltet, wenn er die Info verarbeitet hat
            playerInCollider = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == Player)
        {
            
            playerJustExited = true; //Wird vom Portal wieder ausgeschaltet, wenn er die Info verarbeitet hat
            playerInCollider = false;
        }
    }
}
