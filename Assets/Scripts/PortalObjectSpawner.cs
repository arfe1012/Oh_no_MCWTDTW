using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectSpawner : MonoBehaviour
{
    public GameObject PortalShape;
    public bool spawnShape;
    [SerializeField] private Material material;

    Vector3 newScale = new Vector3(1, 1, 1);




    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnShape)
        {
            StartCoroutine(SpawnPortalCoroutine());
            spawnShape = false;
        }



    }
    IEnumerator SpawnPortalCoroutine()

    {

        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime) //Baut den Swoosh Shader auf
        {
            
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
            if (UnityEngine.Random.value >= 0.9)
            {
                transform.Rotate(1, -1, 1, Space.Self);
            }
        }

    }

 }
