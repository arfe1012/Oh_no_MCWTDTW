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


    public UniversalRenderPipelineAsset urpAsset;
    public Renderer[] rendererList;


    private bool inselWorldActive = false;

    void Update()
    {
        
        if (switchPortal)
        {
            StartCoroutine(SwitchingPortalCoroutine());
            switchPortal = false;
        }


    }

    IEnumerator SwitchingPortalCoroutine()
    {
        for (float dissolve = 0; dissolve <= 1; dissolve += Time.deltaTime)
        {
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }

        if (InselRenderer.enabled)
        {
            InselRenderer.enabled = false;
            KellerRenderer.enabled = true;
        }
        else
        {
            InselRenderer.enabled = true;
            KellerRenderer.enabled = false;
        }

        for (float dissolve = 1; dissolve >= 0; dissolve -= Time.deltaTime)
        {
            material.SetFloat("_DissolveAmount", dissolve);
            yield return null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == Player)
        {
            
            if (InselRenderer.enabled)
            {
                SetFiltering(true);
                Debug.Log("Collided With player und Fliegende Inseln!");
            }
        }
    }




    public void SetFiltering(bool enabled)
    {





    }

}


