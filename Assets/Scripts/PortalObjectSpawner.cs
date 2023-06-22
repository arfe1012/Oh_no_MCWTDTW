using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectSpawner : MonoBehaviour
{
    public GameObject PortalShape;
    [SerializeField] private Material material;
    [SerializeField] private Material ObSpMaterial;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    GameObject prefabToSpawn;

    private void Start()
    {
        material.SetFloat("_DissolveAmount", 0);
        ObSpMaterial.SetFloat("_DissolveAmount", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPrefab1()
    {
        prefabToSpawn = prefab1;
        StartCoroutine(SpawnPortalCoroutine());
    }

    public void SpawnPrefab2()
    {
        prefabToSpawn = prefab1;
        StartCoroutine(SpawnPortalCoroutine());
    }

    public void SpawnPrefab3()
    {
        prefabToSpawn = prefab1;
        StartCoroutine(SpawnPortalCoroutine());
    }


    IEnumerator SpawnPortalCoroutine()

    {
        material.SetFloat("_DissolveAmount", 1);
        for (float dissolve = 0; dissolve <= 0.5; dissolve += Time.deltaTime) //Macht die PocketDim größer
        {
             transform.localScale= new Vector3(dissolve, dissolve, dissolve);
            yield return null;
        }

        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime) //Baut den Swoosh Shader auf
        {
            ObSpMaterial.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }

        SpawnObject(); //Spawnt das Gewünschte Objekt

        for (float dissolve = 1; dissolve >= 0; dissolve -= Time.deltaTime) //Baut den Swoosh Shader ab
        {
            ObSpMaterial.SetFloat("_DissolveAmount", dissolve);
            
            yield return null;
        }

        yield return new WaitForSeconds(5); // Verzögerung von 5 Sekunden
        for (float dissolve = 1; dissolve >= 0; dissolve -= Time.deltaTime) //Baut den Swoosh Shader ab
        {
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }
    }


    void SpawnObject()
    {
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }


    

    

}
