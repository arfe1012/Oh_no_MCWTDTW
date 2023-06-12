using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.Rendering.Universal;


public class PortalManager : MonoBehaviour
{
    [SerializeField] private Material material;

    public float dissolveAmount;
    public bool switchPortal = false;
    public MeshRenderer InselRenderer;
    public MeshRenderer KellerRenderer;
    public GameObject Player;
    public GameObject KellerCollider;
    public GameObject DimensionCollider;
    UniversalAdditionalCameraData additionalCameraData;
    public Camera Camera;

    public Material OberweltSkybox;
    public Material InselSkybox;

    public bool fliegendeInselActive = false;


    private Scene[] scenes;
    private string[] sceneList = new string[2];

    
    private void Start()
    {
        additionalCameraData = Camera.transform.GetComponent<UniversalAdditionalCameraData>();


        
        sceneList[0] = "Außenwelt";
        sceneList[1] = "Floating Island";

        bool iShouldLoadAussenwelt = true;
        scenes = SceneManager.GetAllScenes();
        foreach (Scene sc in scenes) 
        {            
            if (sc.name == "Außenwelt")
            iShouldLoadAussenwelt = true;
        }

        if (iShouldLoadAussenwelt)
        {
            SceneManager.LoadScene("Außenwelt", LoadSceneMode.Additive);
        }

        if (InselRenderer.enabled)
        {
            fliegendeInselActive = true;
        }
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


            
            if (KellerCollider.GetComponent<PlayerColliding>().playerInCollider == false && DimensionCollider.GetComponent<PlayerColliding>().playerInCollider == false && KellerCollider.GetComponent<PlayerColliding>().playerJustExited == false &&  DimensionCollider.GetComponent<PlayerColliding>().playerJustExited == false)
            {
                //Wenn der Spieler Sich in keinem der Portal Collider befindet oder befand, spaart sich der Portal Manager die Abfragen
            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerJustEntered == true && DimensionCollider.GetComponent<PlayerColliding>().playerInCollider == false)
            {
                //Wenn Der Spieler vom Keller ins Poral geht, Werden die Inseln permanent sichtbar
                SetFiltering(1);
                Debug.Log("Insel An");

            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerJustExited == true && DimensionCollider.GetComponent<PlayerColliding>().playerInCollider == false)
            {
                //Wenn Der Spieler vom Keller ins Poral schaut, aber wieder zurück geht, Werden die Inseln wieder nur durchs Portal sichtbar
                SetFiltering(0);
                Debug.Log("Insel Aus");
            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerInCollider == true && DimensionCollider.GetComponent<PlayerColliding>().playerJustExited == true)
            {
                //Wenn Der Spieler die Dimension verlässt, switched das Spiel wieder zur einzigen Sicht durch das Portal
                SetFiltering(0);
                Debug.Log("Insel Aus");
            }
            else if (KellerCollider.GetComponent<PlayerColliding>().playerInCollider == true && DimensionCollider.GetComponent<PlayerColliding>().playerJustEntered == true)
            {
                //Wenn Der Spieler dann aber wieder zurück geht, wird die Dimension wieder eingeblendet
                SetFiltering(1);
                Debug.Log("Insel An");
            }

            //Wenn der Portal Manager alle Infos verarbeitet hat, stellt er die Bools von den Collidern wieder aus
            KellerCollider.GetComponent<PlayerColliding>().playerJustEntered = false;
            KellerCollider.GetComponent<PlayerColliding>().playerJustExited = false;
            DimensionCollider.GetComponent<PlayerColliding>().playerJustEntered = false;
            DimensionCollider.GetComponent<PlayerColliding>().playerJustExited = false;
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
            //Tauscht die Renderer zum Keller (leer) aus
            InselRenderer.enabled = false;
            KellerRenderer.enabled = true;
            LoadScene(0);
            RenderSettings.skybox = OberweltSkybox;

            fliegendeInselActive = false;
        }
        else
        {
            //Tauscht die Renderer zur Insel aus
            InselRenderer.enabled = true;
            KellerRenderer.enabled = false;
            LoadScene(1);
            RenderSettings.skybox = InselSkybox;

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
        //Ändert den Renderer der Camera. Es gibt einen Renderer pro Dimension und einen für den Keller
        //Index 1 für die Inseln, Index 0 für den Keller
        additionalCameraData.SetRenderer(index);
        
    }




    public void LoadScene(int index)
    {


        scenes = SceneManager.GetAllScenes();

        foreach (Scene sc in scenes)
        {
            if (sc.name != "MainScene")
                SceneManager.UnloadSceneAsync(sc.name);
        }
            
        SceneManager.LoadScene(sceneList[index], LoadSceneMode.Additive);

    }



}


