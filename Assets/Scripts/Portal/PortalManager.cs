using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Rendering.Universal;


public class PortalManager : MonoBehaviour
{
    [SerializeField] private Material material;

    public float dissolveAmount;
    public bool switchPortal;
    public MeshRenderer InselRenderer;
    public MeshRenderer KellerRenderer;
    public GameObject Player;
    public GameObject KellerCollider;
    public GameObject DimensionCollider;
    UniversalAdditionalCameraData additionalCameraData;
    public Camera Camera;


    private bool fliegendeInselActive = false;


    
    
    private void Start()
    {
        additionalCameraData = Camera.transform.GetComponent<UniversalAdditionalCameraData>();
    }


    void Update()
    {
        
        if (switchPortal) //Startet den Portal Spawn, wenn switchPortal == true
        {
            StartCoroutine(SwitchingPortalCoroutine());
            switchPortal = false;
        }

        
        if (fliegendeInselActive) // Aktiviert die Sicht auf die Fliegenden Inseln permanent, wenn der Character von Kellerseite durch das Portal steigt
        {
            Debug.Log("FliegendeInselactive");
            if (KellerCollider.GetComponent<PlayerColliding>().playerCollision == false && DimensionCollider.GetComponent<PlayerColliding>().playerCollision == false)
            {
                
            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerCollision == true && DimensionCollider.GetComponent<PlayerColliding>().playerCollision == false)
            {
                SetFiltering(0);
            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerCollision == false && DimensionCollider.GetComponent<PlayerColliding>().playerCollision == true)
            {
                SetFiltering(1);
            }
        }



    }

    IEnumerator SwitchingPortalCoroutine()
    {
        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime) //Baut den Swoosh Shader auf
        {
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }

        if (InselRenderer.enabled)
        {
            InselRenderer.enabled = false;
            KellerRenderer.enabled = true;

            fliegendeInselActive = false;
        }
        else
        {
            InselRenderer.enabled = true;
            KellerRenderer.enabled = false;

            fliegendeInselActive = true;
        }

        for (float dissolve = 1; dissolve >= 0; dissolve -= Time.deltaTime) //Baut den Swoosh Shader auf
        {
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }
    }




    public void SetFiltering(int index)
    {
        additionalCameraData.SetRenderer(index);
    }

}


