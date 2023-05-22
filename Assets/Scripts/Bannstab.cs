using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannstab : MonoBehaviour
{
    public GameObject Flame1;
    public GameObject Flame2;
    public GameObject Line;
    public GameObject[] flamesOfCandles;
    private bool candlesAt0Activated = false;
    private bool candlesAt1Activated = false;
    private bool candlesAt2Activated = false;
    private bool candlesAt3Activated = false;
    private bool candlesAt4Activated = false;
    private Vector3 candle0 = new Vector3(-1, 0, (float)-0.65);
    private Vector3 candle1 = new Vector3((float)-1.04, 0, (float)0.6);
    private Vector3 candle2 = new Vector3((float)0.3, 0, -1);
    private Vector3 candle3 = new Vector3((float)0.2, 0, (float)1.105); // 1, 0, (float)0.1
    private Vector3 candle4 = new Vector3(1, 0, (float)0.1);
    private int index = 0;
    private List<Vector3> drawingOrder;

    // Start is called before the first frame update
    void Start()
    {
        drawingOrder = new List<Vector3>();
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        Line.GetComponent<LineRenderer>().positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (candlesAt0Active() && !candlesAt0Activated)
        {
            candlesAt0Activated = true;
            Line.GetComponent<LineRenderer>().positionCount = index + 1;
            Line.GetComponent<LineRenderer>().SetPosition(index, candle0);
            drawingOrder.Add(candle0);
            index++;
        }
        if (candlesAt1Active() && !candlesAt1Activated)
        {
            candlesAt1Activated = true;
            Line.GetComponent<LineRenderer>().positionCount = index + 1;
            Line.GetComponent<LineRenderer>().SetPosition(index, candle1);
            drawingOrder.Add(candle1);
            index++;
        }
        if (candlesAt2Active() && !candlesAt2Activated)
        {
            candlesAt2Activated = true;
            Line.GetComponent<LineRenderer>().positionCount = index + 1;
            Line.GetComponent<LineRenderer>().SetPosition(index, candle2);
            drawingOrder.Add(candle2);
            index++;
        }
        if (candlesAt3Active() && !candlesAt3Activated)
        {
            candlesAt3Activated = true;
            Line.GetComponent<LineRenderer>().positionCount = index + 1;
            Line.GetComponent<LineRenderer>().SetPosition(index, candle3);
            drawingOrder.Add(candle3);
            index++;
        }
        if (candlesAt4Active() && !candlesAt4Activated)
        {
            candlesAt4Activated = true;
            Line.GetComponent<LineRenderer>().positionCount = index + 1;
            Line.GetComponent<LineRenderer>().SetPosition(index, candle4);
            drawingOrder.Add(candle4);
            index++;
        }
    }

    public void pullTrigger()
    {
        Flame1.SetActive(true);
        Flame2.SetActive(true);
    }

    public void releaseTrigger()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        validateBannkreis();
    }

    private bool candlesAt0Active()
    {
        if (flamesOfCandles[0].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[1].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[2].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[3].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool candlesAt1Active()
    {
        if (flamesOfCandles[4].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[5].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[6].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[7].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt2Active()
    {
        if (flamesOfCandles[8].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[9].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[10].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[11].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt3Active()
    {
        if (flamesOfCandles[12].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[13].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[14].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[15].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt4Active()
    {
        if (flamesOfCandles[16].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[17].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[18].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[19].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void validateBannkreis()
    {
        if(drawingOrder.Count == 3 && drawingOrder[0].Equals(candle0) && drawingOrder[1].Equals(candle1) && drawingOrder[2].Equals(candle3))
        {
            Debug.Log("Correct order");

            /*
             * 
             * Set States for Portals in here
             * 
             */ 
        } else
        {
            Debug.Log("Wrong order");
            resetBannkreis();
        }
    }

    private void resetBannkreis()
    {
        drawingOrder.Clear();
        Vector3[] resetArray = new Vector3[drawingOrder.Count + 1];
        for(int i = 0; i <= drawingOrder.Count; i++)
        {
            Line.GetComponent<LineRenderer>().SetPosition(i, candle0);
        }
        Line.GetComponent<LineRenderer>().positionCount = 0;
        
        for(int i = 0; i < flamesOfCandles.Length; i++)
        {
            flamesOfCandles[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        candlesAt0Activated = false;
        candlesAt1Activated = false;
        candlesAt2Activated = false;
        candlesAt3Activated = false;
        candlesAt4Activated = false;
        index = 0;
    }
}
