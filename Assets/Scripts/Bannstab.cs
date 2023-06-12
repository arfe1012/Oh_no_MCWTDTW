using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannstab : MonoBehaviour
{
    public GameObject Flame1;
    public GameObject Flame2;
    public GameObject Line;
    public GameObject Portal;
    public GameObject[] flamesOfCandles0;
    public GameObject[] flamesOfCandles1;
    public GameObject[] flamesOfCandles2;
    public GameObject[] flamesOfCandles3;
    public GameObject[] flamesOfCandles4;
    private Vector3 candle0 = new Vector3(-1, 0, (float)-0.65);
    private Vector3 candle1 = new Vector3((float)-1.04, 0, (float)0.6);
    private Vector3 candle2 = new Vector3((float)0.3, 0, -1);
    private Vector3 candle3 = new Vector3((float)0.2, 0, (float)1.105);
    private Vector3 candle4 = new Vector3(1, 0, (float)0.1);
    


    private int lineRendererSize = 0;
    private List<string> drawingOrder = new List<string>();
    private List<string> connections = new List<string>();
    private bool firstCandleLit = false; // Only if the line should be connected to the Bannstab
    private List<string> lastTwoCandles = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lastTwoCandles.Add("");
        lastTwoCandles.Add("");
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        Line.GetComponent<LineRenderer>().positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pullTrigger()
    {
        Flame1.SetActive(true);
        Flame2.SetActive(true);

        resetBannkreis();
        
    }

    public void releaseTrigger()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
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
                Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle0);
                drawingOrder.Add(candleName);
                lineRendererSize++;

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
                Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle1);
                drawingOrder.Add(candleName);
                lineRendererSize++;

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
                Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle2);
                drawingOrder.Add(candleName);
                lineRendererSize++;

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
                Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle3);
                drawingOrder.Add(candleName);
                lineRendererSize++;

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
                Line.GetComponent<LineRenderer>().positionCount = lineRendererSize + 1;
                Line.GetComponent<LineRenderer>().SetPosition(lineRendererSize, candle4);
                drawingOrder.Add(candleName);
                lineRendererSize++;

                connections.Add(candleName + "+" + lastTwoCandles[1]);
                connections.Add(lastTwoCandles[1] + "+" + candleName);
                return true;
            }
        }
        return false;
    }

    private void validateBannkreis()
    {
        

        if (checkForPattern() == true)
        {
            //Aktiviert die Dimension
            Debug.Log("Correct order");

            if (!Portal.GetComponent<PortalManager>().fliegendeInselActive)
            {
                Portal.GetComponent<PortalManager>().switchPortal = true;
            }
        }
        else
        {
            //setzt die Linie und das Portal zur�ck mit resetBannkreis()
            Debug.Log("Wrong order");
            resetBannkreis();
        }
    }

    private void resetBannkreis()
    {
        connections.Clear();
        drawingOrder.Clear();
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

        if (Portal.GetComponent<PortalManager>().fliegendeInselActive)
        {
            Portal.GetComponent<PortalManager>().switchPortal = true;
        }
    }

    private bool checkForPattern()
    {
        if (
            (drawingOrder.Count == 10 && connections.Contains("Pillar+Pillar (1)") && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (2)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (2)+Pillar (3)") && connections.Contains("Pillar (2)+Pillar (4)") && connections.Contains("Pillar (3)+Pillar (4)"))
            || (drawingOrder.Count == 6 && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar (2)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)"))
            || (drawingOrder.Count == 7 && connections.Contains("Pillar+Pillar (2)") && connections.Contains("Pillar+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (3)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)") && connections.Contains("Pillar+Pillar (1)"))
            || (drawingOrder.Count == 7 && connections.Contains("Pillar (2)+Pillar (4)") && connections.Contains("Pillar+Pillar (4)") && connections.Contains("Pillar+Pillar (1)") && connections.Contains("Pillar (1)+Pillar (4)") && connections.Contains("Pillar (3)+Pillar (4)") && connections.Contains("Pillar (1)+Pillar (3)"))
            || (drawingOrder.Count == 2 && connections.Contains("Pillar+Pillar (1)") )
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
