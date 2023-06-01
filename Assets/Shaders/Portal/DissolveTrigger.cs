using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    [SerializeField] private Material material;

    private float dissolveAmount;
    public bool active;
    public bool deactive;
    public MeshRenderer PortalRender;


    // Update is called once per frame
    void Update()
    {
      if (active)
      {
            Activate();
            //active = false;

      }
      if (active)
      {
          Deactivate();
          deactive = false;
      }


    }


    void Activate()
    {
        while (dissolveAmount != 1)
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount + Time.deltaTime, -1, 1);
            material.SetFloat("_DissolveAmount", dissolveAmount);
            
        }
        PortalRender.enabled = true;

        while (dissolveAmount != -1)
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount - Time.deltaTime, -1, 1);
            material.SetFloat("_DissolveAmount", dissolveAmount);

        }

    }

    void Deactivate()
    {
        while (dissolveAmount != 1)
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount + Time.deltaTime, -1, 1);
            material.SetFloat("_DissolveAmount", dissolveAmount);

        }
        PortalRender.enabled = false;

        while (dissolveAmount != -1)
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount - Time.deltaTime, -1, 1);
            material.SetFloat("_DissolveAmount", dissolveAmount);

        }

    }

}

