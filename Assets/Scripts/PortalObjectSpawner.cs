using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PortalObjectSpawner : MonoBehaviour
{
    public GameObject PortalShape;
    public GameObject Sphere;
    [SerializeField] private Material material;
    [SerializeField] private Material ObSpMaterial;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    AudioSource audioData;

    GameObject prefabToSpawn;
    public bool collapse;
    private float timer = 0.0f;


    private Vector3 UrsprungsPosition;
    private Vector3 StonePosition;

    private void Start()
    {
        PortalShape.SetActive(false);
        material.SetFloat("_DissolveAmount", 0);
        ObSpMaterial.SetFloat("_DissolveAmount", 0);
        UrsprungsPosition = transform.localPosition;

        audioData = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (collapse)
        {
            if (timer == 0)
            {
                audioData.Play(0);
            }
            timer += Time.deltaTime;
            
            if (timer <= 3)
            {
                transform.localPosition += transform.right.normalized * 0.01f * (Mathf.Sin(Time.time * timer*3));
                transform.localPosition += transform.up.normalized * 0.01f * (Mathf.Sin(Time.time * timer*4));
            }
            else
            {
                transform.localPosition = UrsprungsPosition;
                material.SetFloat("_DissolveAmount", 0);
                PortalShape.SetActive(false);
                timer = 0;
                collapse = false;
            }
        }
        
    }

    public void SpawnPrefab1()
    {
        prefabToSpawn = prefab1;
        StartCoroutine(SpawnPortalCoroutine());
    }

    public void SpawnPrefab2()
    {
        prefabToSpawn = prefab2;
        StartCoroutine(SpawnPortalCoroutine());
    }

    public void SpawnPrefab3()
    {
        prefabToSpawn = prefab3;
        StartCoroutine(SpawnPortalCoroutine());
    }


    IEnumerator SpawnPortalCoroutine()

    {
        PortalShape.SetActive(true);
        material.SetFloat("_DissolveAmount", 1);

        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime) //Macht die PocketDim größer
        {
            PortalShape.transform.localScale = new Vector3(dissolve, 0.01f, dissolve);
            yield return null;
        }
        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime)
        {
            PortalShape.transform.localScale= new Vector3(1, dissolve, 1);
            yield return null;
        }

        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime) //Baut den Swoosh Shader auf
        {
            ObSpMaterial.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }

        SpawnObject(); //Spawnt das Gewünschte Objekt

        for (float dissolve = 1f; dissolve >= 0; dissolve -= Time.deltaTime) //Baut den Swoosh Shader ab
        {
            ObSpMaterial.SetFloat("_DissolveAmount", dissolve);
            
            yield return null;
        }

    }


    void SpawnObject()
    {
        if (GameObject.Find(prefabToSpawn.name + "(Clone)") == null)
        { 
            Instantiate(prefabToSpawn, Sphere.transform.position, Quaternion.identity);
        }
        else
        {
            collapse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name.Contains("Stein"))
        {
            collapse = true;
        }
    }




}
