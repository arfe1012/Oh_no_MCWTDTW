using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SwitchSceneToMenue : MonoBehaviour
{

    public GameObject ChainManager;
    private void Update()
    {
        if (ChainManager.GetComponent<EvilFalldown>().chains == 0)
        {
            StartCoroutine(Wait());


        }


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene(0);
    }
}
