using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannstab : MonoBehaviour
{
    // Flames of Bannstab
    public GameObject Flame1;
    public GameObject Flame2;

    // Connection Line
    public GameObject Line;

    public GameObject Portal;
    public GameObject PocketPortal;

    // For each pillar with candles one array that holds those candles
    public GameObject[] flamesOfCandles0;
    public GameObject[] flamesOfCandles1;
    public GameObject[] flamesOfCandles2;
    public GameObject[] flamesOfCandles3;
    public GameObject[] flamesOfCandles4;

    //candle positions are fixed
    private Vector3 candle0 = new Vector3(-0.88f, 0.2f, -0.56f);
    private Vector3 candle1 = new Vector3(-0.89f, 0.2f, 0.48f);
    private Vector3 candle2 = new Vector3(0.24f, 0.35f, -0.97f);
    private Vector3 candle3 = new Vector3(0.2f, 0.35f, 0.87f);
    private Vector3 candle4 = new Vector3(0.91f, 0.5f, -0.02f);

    // For having a reference point (only used for line to tip of Bannstab)
    private Vector3 bannkreisCenter;

    // could get rid of this variable but magically makes everything work...
    private int lineRendererSize = 0;

    // Order drawn by the Player is stored in here 
    private List<string> drawingOrder = new List<string>();

    // similar to drawingOrder
    private List<string> connections = new List<string>();

    // So the tip of Bannstab is only connected, if a candle is already lit
    private bool firstCandleLit = false;
    private List<string> lastTwoCandles = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lastTwoCandles.Add("");
        lastTwoCandles.Add("");
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        Flame1.GetComponent<Collider>().enabled = false;
        Flame2.GetComponent<Collider>().enabled = false;
        Line.GetComponent<LineRenderer>().positionCount = 0;
        bannkreisCenter.Set(4.8f, 0.8f, 3.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (firstCandleLit)
        {
            // make newest point of the line connected to tip of Bannstab
            int currentLineCount = Line.GetComponent<LineRenderer>().positionCount;
            Vector3 newestCandle = Line.GetComponent<LineRenderer>().GetPosition(currentLineCount - 1);
            if (newestCandle != candle0 && newestCandle != candle1 && newestCandle != candle2 && newestCandle != candle3 && newestCandle != candle4)
            {
                Line.GetComponent<LineRenderer>().SetPosition(currentLineCount - 1, GameObject.Find("BannstabFlamme1").transform.position - bannkreisCenter);
            }
        }
    }

    public void pullTrigger()
    {
        Flame1.SetActive(true);
        Flame2.SetActive(true);
        Flame1.GetComponent<Collider>().enabled = true;
        Flame2.GetComponent<Collider>().enabled = true;

        resetBannkreis();
        
    }

    public void releaseTrigger()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        Flame1.GetComponent<Collider>().enabled = false;
        Flame2.GetComponent<Collider>().enabled = false;
        validateBannkreis();
    }

    private void OnTriggerEnter(Collider other)
    {
        string colliderName = other.gameObject.name;
        if (colliderName.StartsWith("Pillar"))
        {
            if (pushNewCandle(colliderName))
            {
                activateCandle(colliderName);
            }
        }
    }

    private bool pushNewCandle(string candleName)
    {
        if(lastTwoCandles[0] != candleName && lastTwoCandles[1] != candleName && !connections.Contains(candleName + "+" + lastTwoCandles[0]) && !connections.Contains(lastTwoCandles[0] + "+" + candleName))
        {
            lastTwoCandles[1] = lastTwoCandles[0];
            lastTwoCandles[0] = candleName;
            return true;
        }
        return false;
    }

    private bool activateCandle(string candleName)
    {
        int index = 0;
        if (candleName == "Pillar")
        {
            while (flamesOfCandles0[index].transform.GetChild(1).gameObject.activeInHierarchy && index < 4)
            {
                flamesOfCandles0[index].transform.GetChild(1).gameObject.SetActive(true);
                index++;
            }
            if (index < 4)
            {
                flamesOfCandles0[index].transform.GetChild(1).gameObject.SetActive(true);
                Line.GetComponent<LineRenderer>().positionCount++;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle0);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                if (lineRendererSize == 1)
                {
                    Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                    firstCandleLit = true;
                    Debug.Log("" + firstCandleLit + Line.GetComponent<LineRenderer>().positionCount + lineRendererSize);
                }

                connections.Add(candleName + "+" + lastTwoCandles[1]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        else if (candleName == "Pillar (1)")
        {
            while (flamesOfCandles1[index].transform.GetChild(1).gameObject.activeInHierarchy && index < 4)
            {
                flamesOfCandles1[index].transform.GetChild(1).gameObject.SetActive(true);
                index++;
            }
            if (index < 4)
            {
                flamesOfCandles1[index].transform.GetChild(1).gameObject.SetActive(true);
                Line.GetComponent<LineRenderer>().positionCount++;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle1);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                if (lineRendererSize == 1)
                {
                    Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                    firstCandleLit = true;
                    
                }

                connections.Add(candleName + "+" + lastTwoCandles[1]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        else if (candleName == "Pillar (2)")
        {
            while (flamesOfCandles2[index].transform.GetChild(1).gameObject.activeInHierarchy && index < 4)
            {
                flamesOfCandles2[index].transform.GetChild(1).gameObject.SetActive(true);
                index++;
            }
            if (index < 4)
            {
                flamesOfCandles2[index].transform.GetChild(1).gameObject.SetActive(true);
                Line.GetComponent<LineRenderer>().positionCount++;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle2);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                if (lineRendererSize == 1)
                {
                    Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                    firstCandleLit = true;
                    Debug.Log("" + firstCandleLit + Line.GetComponent<LineRenderer>().positionCount + lineRendererSize);
                }

                connections.Add(candleName + "+" + lastTwoCandles[1]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        else if (candleName == "Pillar (3)")
        {
            while (flamesOfCandles3[index].transform.GetChild(1).gameObject.activeInHierarchy && index < 4)
            {
                flamesOfCandles3[index].transform.GetChild(1).gameObject.SetActive(true);
                index++;
            }
            if (index < 4)
            {
                flamesOfCandles3[index].transform.GetChild(1).gameObject.SetActive(true);
                Line.GetComponent<LineRenderer>().positionCount++;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle3);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                if (lineRendererSize == 1)
                {
                    Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                    firstCandleLit = true;
                    Debug.Log("" + firstCandleLit + Line.GetComponent<LineRenderer>().positionCount + lineRendererSize);
                }

                connections.Add(candleName + "+" + lastTwoCandles[0]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        else if (candleName == "Pillar (4)")
        {
            while (flamesOfCandles4[index].transform.GetChild(1).gameObject.activeInHierarchy && index < 4)
            {
                flamesOfCandles4[index].transform.GetChild(1).gameObject.SetActive(true);
                index++;
            }
            if (index < 4)
            {
                flamesOfCandles4[index].transform.GetChild(1).gameObject.SetActive(true);
                Line.GetComponent<LineRenderer>().positionCount++;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle4);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                if (lineRendererSize == 1)
                {
                    Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                    firstCandleLit = true;
                    Debug.Log("" + firstCandleLit + Line.GetComponent<LineRenderer>().positionCount + lineRendererSize);
                }

                connections.Add(candleName + "+" + lastTwoCandles[1]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        return false;
    }

    private void validateBannkreis()
    {
        

        if (checkForPattern() == 0) // Checkt auf PortalMuster
        {
            //Aktiviert die Dimension
            Debug.Log("Correct order");
            firstCandleLit = false;
            // Remove Line to the Bannstab
            Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, Line.GetComponent<LineRenderer>().GetPosition(lineRendererSize - 1));

            // open Portal TODO Logik muss noch überarbeitet werden wann das Portal auf und zu geht
            if (!Portal.GetComponent<PortalManager>().switchPortal)
            {
                Portal.GetComponent<PortalManager>().switchPortal = true;
            }

        }
        else if (checkForPattern() == 1) //Checkt auf Baustein1 Muster
        {
            
            Debug.Log("Spawnt Object 1"); 
            
            firstCandleLit = false;
            // Remove Line to the Bannstab
            Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, Line.GetComponent<LineRenderer>().GetPosition(lineRendererSize - 1));
            PocketPortal.GetComponent<PortalObjectSpawner>().SpawnPrefab1();
        }
        else if (checkForPattern() == 2) //Checkt auf Baustein2 Muster
        {
            
            Debug.Log("Spawnt Object 2");

            firstCandleLit = false;
            // Remove Line to the Bannstab
            Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, Line.GetComponent<LineRenderer>().GetPosition(lineRendererSize - 1));
            PocketPortal.GetComponent<PortalObjectSpawner>().SpawnPrefab2();
        }
        else if (checkForPattern() == 3) //Checkt auf Baustein3 Muster
        {

            Debug.Log("Spawnt Object 3");

            firstCandleLit = false;
            // Remove Line to the Bannstab
            Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, Line.GetComponent<LineRenderer>().GetPosition(lineRendererSize - 1));
            PocketPortal.GetComponent<PortalObjectSpawner>().SpawnPrefab3();
        }
        else
        {
            //setzt die Linie und das Portal zurück mit resetBannkreis()
            Debug.Log("Wrong order: " );
            firstCandleLit = false;
            resetBannkreis();
        }
    }

    private void resetBannkreis()
    {
        connections.Clear();
        drawingOrder.Clear();
        Portal.GetComponent<PortalManager>().switchPortal = false;
        Vector3[] resetArray = new Vector3[drawingOrder.Count + 1];
        if(drawingOrder.Count != 0)
        {
            for (int i = 0; i <= drawingOrder.Count; i++)
            {
                Line.GetComponent<LineRenderer>().SetPosition(i, candle0);
            }
        }
        
        Line.GetComponent<LineRenderer>().positionCount = 0;
        
        for(int i = 0; i < 4; i++)
        {
            flamesOfCandles0[i].transform.GetChild(1).gameObject.SetActive(false);
            flamesOfCandles1[i].transform.GetChild(1).gameObject.SetActive(false);
            flamesOfCandles2[i].transform.GetChild(1).gameObject.SetActive(false);
            flamesOfCandles3[i].transform.GetChild(1).gameObject.SetActive(false);
            flamesOfCandles4[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        lastTwoCandles[0] = "";
        lastTwoCandles[1] = "";
        lineRendererSize = 0;
        firstCandleLit = false;

        if (Portal.GetComponent<PortalManager>().fliegendeInselActive)
        {
            Portal.GetComponent<PortalManager>().switchPortal = true;
        }
    }

    private int checkForPattern()
    {

        

        


        if (drawingOrder.Count == 2 && connections.Contains("Pillar+Pillar (1)"))
        {
            return 0;
        }
        else if (drawingOrder.Count == 2 && connections.Contains("Pillar (1)+Pillar (3)"))
        {
            return 1;
        }
        else if (drawingOrder.Count == 2 && connections.Contains("Pillar (3)+Pillar (4)"))
        {
            return 2;
        }
        else if (drawingOrder.Count == 2 && connections.Contains("Pillar (4)+Pillar (2)"))
        {
            return 3;
        }
        else
        {
            return -1;
        }


        /*if (
            (drawingOrder.Count == 10 && connections.Contains("Pillar+Pillar (1)") && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (2)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (2)+Pillar (3)") && connections.Contains("Pillar (2)+Pillar (4)") && connections.Contains("Pillar (3)+Pillar (4)"))
            || (drawingOrder.Count == 6 && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar (2)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)"))
            || (drawingOrder.Count == 7 && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)") && connections.Contains("Pillar+Pillar (1)"))
            || (drawingOrder.Count == 7 && connections.Contains("Pillar (2)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)") && connections.Contains("Pillar+Pillar (1)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar (3)+Pillar (4)") && connections.Contains("Pillar (1)+Pillar (3)"))
            || (drawingOrder.Count == 2 && connections.Contains("Pillar+Pillar (1)") )
            )
        {
            return 0;
        }
        else
        {
            return 1;
        }*/




    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
}
