using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    [SerializeField] private Material material;

    public float dissolveAmount;
    public bool switchPortal;
    public MeshRenderer InselRenderer;
    public MeshRenderer KellerRenderer;

    // Update is called once per frame
    void Update()
    {
        if (switchPortal)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolveAmount);
        }
        if (switchPortal && dissolveAmount >= 1)
        {
            switchPortal = false;

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
            
        }
        if (!switchPortal)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolveAmount);
        }

    }


}

